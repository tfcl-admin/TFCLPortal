using System.Collections.Generic;
using TFCLPortal.Roles.Dto;

namespace TFCLPortal.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}