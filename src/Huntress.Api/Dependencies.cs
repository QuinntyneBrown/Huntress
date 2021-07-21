using Huntress.Api.Data;
using Huntress.Api.Extensions;
using Huntress.Api.Interfaces;
using Huntress.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Huntress.Api
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Huntress",
                    Description = "e-Commerce",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Quinntyne Brown",
                        Email = "quinntynebrown@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowCredentials()));

            services.AddValidation(typeof(Startup));

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(IHuntressDbContext));

            services.AddTransient<IHuntressDbContext, HuntressDbContext>();

            services.AddTransient<IStripeClient, StripeClient>();

            services.AddDbContext<HuntressDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(Huntress.Api))
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();
            });

            services.AddControllers();
        }
    }
}
