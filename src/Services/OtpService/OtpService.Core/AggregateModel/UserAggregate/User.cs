// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace OtpService.Core.AggregateModel.UserAggregate;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
}