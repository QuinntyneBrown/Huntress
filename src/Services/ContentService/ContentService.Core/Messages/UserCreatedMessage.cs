// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;

namespace ContentService.Core.Messages;

public class UserCreatedMessage : IRequest
{
    public UserCreatedMessage()
    {
    }

    public Guid UserId { get; set; }
    public string Username { get; set; }

}


