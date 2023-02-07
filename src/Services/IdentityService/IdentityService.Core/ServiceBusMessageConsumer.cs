// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;
using Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IdentityService.Api;

public class ServiceBusMessageConsumer: BackgroundService
{
    private readonly ILogger<ServiceBusMessageConsumer> _logger;
    private readonly IMediator _mediator;
    private readonly IMessagingClient _messagingClient;

    public ServiceBusMessageConsumer(
        ILogger<ServiceBusMessageConsumer> logger,
        IMessagingClient messagingClient,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _messagingClient = messagingClient ?? throw new ArgumentNullException(nameof(messagingClient));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _messagingClient.StartAsync(stoppingToken);

        while(!stoppingToken.IsCancellationRequested) {

            try
            {
                var message = await _messagingClient.ReceiveAsync(new ReceiveRequest());

                var messageType = message.MessageAttributes["MessageType"];

                var type = Type.GetType($"IdentityService.Core.Messages.{messageType}");

                var request = JsonConvert.DeserializeObject(message.Body, type!) as IRequest;

                await _mediator.Send(request!);

                await Task.Delay(100);
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.Message);

                continue;
            }
        }
    }
}


