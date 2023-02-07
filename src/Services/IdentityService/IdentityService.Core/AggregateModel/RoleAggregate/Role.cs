// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;

namespace IdentityService.Core.AggregateModel.RoleAggregate;

public class Role
{
    public Guid RoleId { get; init; }
    public string Name { get; init; }
    public List<User> Users { get; init; }
    public List<Privilege> Privileges { get; init; }
    public Role(string name)
    {
        Name = name;
        Privileges = new List<Privilege>();
        Users = new List<User>();
    }
}
