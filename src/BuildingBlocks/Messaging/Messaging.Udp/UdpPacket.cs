// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Messaging.Udp;

public class UdpPacket {
    public DateTime ReceivedOn { get; set; }
    public string SourceIpAddress { get; set; }
    public byte[] Data { get; set; }
}

