using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class Authenticate
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Username).NotNull();
                RuleFor(x => x.Password).NotNull();
            }
        }

        public record Request(string Username, string Password) : IRequest<Response>;

        public record Response(string AccessToken, System.Guid UserId);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
            private readonly IPasswordHasher _passwordHasher;
            private readonly ITokenProvider _tokenProvider;
            private readonly ITokenBuilder _tokenBuilder;

            public Handler(IHuntressDbContext context, ITokenProvider tokenProvider, IPasswordHasher passwordHasher, ITokenBuilder tokenBuilder)
            {
                _context = context;
                _tokenProvider = tokenProvider;
                _passwordHasher = passwordHasher;
                _tokenBuilder = tokenBuilder;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .Include(x => x.Roles)
                    .ThenInclude(x => x.Privileges)
                    .SingleOrDefaultAsync(x => x.Username == request.Username);

                if (user == null)
                    throw new Exception();

                if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, request.Password)))
                    throw new Exception();

                _tokenBuilder
                    .AddUsername(user.Username)
                    .AddClaim(new System.Security.Claims.Claim(Constants.ClaimTypes.UserId, $"{user.UserId}"))
                    .AddClaim(new System.Security.Claims.Claim(Constants.ClaimTypes.Username, $"{user.Username}"));

                foreach(var role in user.Roles)
                {
                    _tokenBuilder.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role.Name));

                    foreach(var privilege in role.Privileges)
                    {
                        _tokenBuilder.AddClaim(new System.Security.Claims.Claim(Constants.ClaimTypes.Privilege, $"{privilege.Aggregate}-{privilege.AccessRight}"));
                    }
                }
                return new(_tokenBuilder.Build(), user.UserId);

            }

            public bool ValidateUser(User user, string transformedPassword)
            {
                if (user == null || transformedPassword == null)
                    return false;

                return user.Password == transformedPassword;
            }
        }
    }
}
