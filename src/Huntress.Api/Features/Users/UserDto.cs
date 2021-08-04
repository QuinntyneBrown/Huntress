using Huntress.Api.Models;
using System;
using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class UserDto
    {
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
