// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Messaging.Internals;
using System.Net.Sockets;

namespace Messaging.Udp;

public class UdpListenerBase: Observable<UdpPacket> {
    protected readonly UdpClient _inner;

	public UdpListenerBase(UdpClient inner)
	{
		_inner = inner ?? throw new ArgumentNullException(nameof(inner));
	}

	public async Task Start(CancellationToken cancellationToken)
	{
		await Task.Factory.StartNew(async () =>
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				var result = await _inner.ReceiveAsync(cancellationToken);

				Broadcast(new UdpPacket()
				{
					ReceivedOn = DateTime.UtcNow,
					Data = result.Buffer,
					SourceIpAddress = $"{result.RemoteEndPoint.Address}"
				});

			}
		}, TaskCreationOptions.LongRunning);
	}
}

