using Abp.Authorization;
using TFCLPortal.Authorization.Roles;
using TFCLPortal.Authorization.Users;

namespace TFCLPortal.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
