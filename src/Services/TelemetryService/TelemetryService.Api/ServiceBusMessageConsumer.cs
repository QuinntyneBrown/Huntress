// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Messaging;
using Messaging.Udp;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace TelemetryService.Api;

public class ServiceBusMessageConsumer : BackgroundService
{
    private readonly ILogger<ServiceBusMessageConsumer> _logger;

    private UdpClient _client;

    private readonly IUdpClientFactory _udpClientFactory;

    private readonly IHubContext<TelemetryHub, ITelemetryHub> _hubContext;

    public ServiceBusMessageConsumer(
        ILogger<ServiceBusMessageConsumer> logger,
        IUdpClientFactory udpClientFactory,
        IHubContext<TelemetryHub, ITelemetryHub> hubContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _udpClientFactory = udpClientFactory;
        _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _client = _udpClientFactory.Create();

        while (!stoppingToken.IsCancellationRequested)
        {

            var result = await _client.ReceiveAsync(stoppingToken);

            var json = System.Text.Encoding.UTF8.GetString(result.Buffer);

            var message = System.Text.Json.JsonSerializer.Deserialize<ServiceBusMessage>(json)!;

            if (message.MessageAttributes["MessageType"] == "TelemetryMessage")
            {
                await _hubContext.Clients.All.Telemetry(json);
            }
        }
    }
}


