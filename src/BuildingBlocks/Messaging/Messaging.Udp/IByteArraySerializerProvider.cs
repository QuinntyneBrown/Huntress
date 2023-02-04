// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Messaging.Udp;

public interface IByteArraySerializerProvider
{
    IByteArraySerializer Get(dynamic input);
}


