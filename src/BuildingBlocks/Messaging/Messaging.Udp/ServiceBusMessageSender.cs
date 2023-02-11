// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace Messaging.Udp;

public class ServiceBusMessageSender: IServiceBusMessageSender
{
    private readonly ILogger<ServiceBusMessageSender> _logger;
    private readonly UdpClient _client;

    public ServiceBusMessageSender(
        ILogger<ServiceBusMessageSender> logger, IUdpClientFactory udpClientFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = udpClientFactory.Create();
    }

    public async Task Send(object message)
    {
        var messageType = message.GetType().Name;

        _logger.LogInformation("Send Message: {messageType}", messageType);

        var serviceBusMessage = new ServiceBusMessage(new Dictionary<string, string>()
        {
            { "MessageType", messageType }
        
        }, JsonConvert.SerializeObject(message));

        var json = JsonConvert.SerializeObject(serviceBusMessage);

        var bytesToSend = System.Text.Encoding.UTF8.GetBytes(json);

        _logger.LogInformation("Sending to Ip and Port: {multiCastGroupIp}:{broadcastPort}", UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);

        await _client.SendAsync(bytesToSend, UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);

    }
}