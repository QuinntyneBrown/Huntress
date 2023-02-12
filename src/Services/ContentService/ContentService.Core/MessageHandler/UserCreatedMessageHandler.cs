// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core.Messages;
using MediatR;

namespace ContentService.Core.MessageHandler;

public class UserCreatedMessageHandler: IRequestHandler<UserCreatedMessage>
{
    private readonly ILogger<UserCreatedMessageHandler> _logger;
    private readonly IContentServiceDbContext _context;

    public UserCreatedMessageHandler(
        ILogger<UserCreatedMessageHandler> logger, 
        IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Unit> Handle(UserCreatedMessage message,CancellationToken cancellationToken)
    {
        _logger.LogInformation("Message Handled: {message}", message);

        return new();

    }

}


