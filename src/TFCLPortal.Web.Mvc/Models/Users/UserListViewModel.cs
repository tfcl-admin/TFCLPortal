using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TFCLPortal.Roles.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }

    public class UserEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
