using System.Collections.Generic;
using TFCLPortal.Roles.Dto;

namespace TFCLPortal.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
