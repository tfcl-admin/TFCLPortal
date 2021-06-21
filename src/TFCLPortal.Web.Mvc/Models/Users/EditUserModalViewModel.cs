using System.Collections.Generic;
using System.Linq;
using TFCLPortal.Roles.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
        public int? BranchId { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
