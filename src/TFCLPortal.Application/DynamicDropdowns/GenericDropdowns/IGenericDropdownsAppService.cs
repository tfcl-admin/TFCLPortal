using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.GenericDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.GenericDropdowns
{
    public interface IGenericDropdownsAppService : IApplicationService
    {
        Task<GenericDropdownDto> GetAllDropdownsDataAsync();
        string GetDropdownUpdateStatus();
        string ToggleDropdownUpdateStatus();


    }
}
