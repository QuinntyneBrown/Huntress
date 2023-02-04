// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Messaging.Udp;

public class ServiceBusMessageSender: IServiceBusMessageSender
{
    private readonly ILogger<ServiceBusMessageSender> _logger;
    private readonly IUdpClientFactory _udpClientFactory;
    private readonly IByteArraySerializerProvider _byteArraySerializerProvider;
    public ServiceBusMessageSender(
        ILogger<ServiceBusMessageSender> logger,
        IByteArraySerializerProvider byteArraySerializerProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _byteArraySerializerProvider = byteArraySerializerProvider ?? throw new ArgumentNullException(nameof(byteArraySerializerProvider));
    }

    public async Task Send<T>(T message)
        where T : class, IServiceBusMessage
    {
        var serializer = _byteArraySerializerProvider.Get(message);

        var bytesToSend = serializer.Serialize(message);

        await new UdpClient().SendAsync(bytesToSend, bytesToSend.Length, UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);
    }
}