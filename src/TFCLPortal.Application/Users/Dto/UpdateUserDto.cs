using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Users.Dto
{
    public class UpdateUserDto
    {
        public UserDto User { get; set; }
        public string[] RoleNames { get; set; }

        //public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
