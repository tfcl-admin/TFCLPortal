using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.NatureOfBusinesses
{
    public interface INatureOfBusinessAppService : IApplicationService
    {
        Task<ListResultDto<NatureOfBusinessListDto>> GetAllNatureOfBusiness();
        Task CreateNatureOfBusiness(CreateNatureOfBusinessDto input);
        List<NatureOfBusinessListDto> GetAllList();

    }
}
