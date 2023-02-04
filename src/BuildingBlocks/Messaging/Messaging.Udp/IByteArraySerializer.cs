// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Messaging.Udp;

public interface IByteArraySerializer
{
    bool CanHandle(byte[] data);

    bool CanHandle(IServiceBusMessage message);

    int Priority { get; }

    byte[] Serialize(IServiceBusMessage message);

    IServiceBusMessage Deserialize(byte[] bytes);

}


