// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Messaging.Internals;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Messaging.Udp;

public class ServiceBusMessageListener: Observable<IServiceBusMessage>, IServiceBusMessageListener
{
    private readonly ILogger<ServiceBusMessageListener> _logger;
    private readonly UdpClient _client;
    private IByteArraySerializerProvider _byteArraySerializerProvider;
    
    public ServiceBusMessageListener(
        ILogger<ServiceBusMessageListener> logger,
        IUdpClientFactory udpClientFactory,
        IByteArraySerializerProvider byteArraySerializerProvider
        ){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = udpClientFactory.Create();
        _byteArraySerializerProvider = byteArraySerializerProvider ?? throw new ArgumentNullException(nameof(byteArraySerializerProvider));
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        while(!cancellationToken.IsCancellationRequested)
        {
            var result = await _client.ReceiveAsync(cancellationToken);

            var serializer = _byteArraySerializerProvider.Get(result.Buffer);

            Broadcast(serializer.Deserialize(result.Buffer));
        }        
    }
}


