// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;
using Messaging;

namespace IdentityService.Api;

public class ServiceBusWorker: BackgroundService, IObserver<IServiceBusMessage>
{
    private readonly ILogger<ServiceBusWorker> _logger;
    private readonly IServiceBusMessageListener _serviceBusMessageListener;
    private readonly IMediator _mediator;
    public ServiceBusWorker(
        ILogger<ServiceBusWorker> logger,
        IServiceBusMessageListener serviceBusMessageListener)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceBusMessageListener = serviceBusMessageListener ?? throw new ArgumentNullException(nameof(serviceBusMessageListener));
    }

    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(IServiceBusMessage value) => _mediator.Publish(value);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _serviceBusMessageListener.Subscribe(this);

        await _serviceBusMessageListener.StartAsync(stoppingToken);
    }
}


