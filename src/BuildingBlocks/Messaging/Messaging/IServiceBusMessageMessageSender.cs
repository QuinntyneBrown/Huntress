// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Messaging;

public interface IServiceBusMessageSender
{
    Task Send<T>(T message)
       where T : class, IServiceBusMessage;
}