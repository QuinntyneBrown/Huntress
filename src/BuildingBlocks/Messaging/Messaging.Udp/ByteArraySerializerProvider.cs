// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Messaging.Udp;

public class ByteArraySerializerProvider: IByteArraySerializerProvider
{
    private readonly ILogger<ByteArraySerializerProvider> _logger;
    private readonly IEnumerable<IByteArraySerializer> _byteArraySerializers;

    public ByteArraySerializerProvider(
        ILogger<ByteArraySerializerProvider> logger,
        IEnumerable<IByteArraySerializer> byteArraySerializers)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _byteArraySerializers = byteArraySerializers ?? throw new ArgumentNullException(nameof(byteArraySerializers));
    }

    public IByteArraySerializer Get(dynamic input) => Get(input);
    public IByteArraySerializer Get(byte[] bytes)
    {
        var serializer = _byteArraySerializers.Where(x => x.CanHandle(bytes)).OrderBy(x => x.Priority).First();

        return serializer;
    }

    public IByteArraySerializer Get(IServiceBusMessage message)
    {
        var serializer = _byteArraySerializers.Where(x => x.CanHandle(message)).OrderBy(x => x.Priority).First();

        return serializer;
    }

}


