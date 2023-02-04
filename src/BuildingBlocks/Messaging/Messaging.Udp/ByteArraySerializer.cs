// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Messaging.Udp;

public class ByteArraySerializer: IByteArraySerializer
{
    private readonly ILogger<ByteArraySerializer> _logger;

    public ByteArraySerializer(ILogger<ByteArraySerializer> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int Priority => 0;

    public bool CanHandle(byte[] data) => true;

    public bool CanHandle(IServiceBusMessage message) => true;

    public IServiceBusMessage Deserialize(byte[] bytes)
    {
        var json = System.Text.Encoding.UTF8.GetString(bytes);

        var serviceBusMessage = JsonConvert.DeserializeObject<IServiceBusMessage>(json, new JsonSerializerSettings()
        { 
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        if(serviceBusMessage == null)
        {
            throw new InvalidOperationException();
        }

        return serviceBusMessage;
    }

    public byte[] Serialize(IServiceBusMessage message)
    {
        var json = JsonConvert.SerializeObject(message, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        return System.Text.Encoding.UTF8.GetBytes(json);
    }
}


