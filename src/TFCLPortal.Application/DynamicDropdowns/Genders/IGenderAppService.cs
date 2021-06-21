using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Genders
{
    public interface IGenderAppService : IApplicationService
    {
        Task<ListResultDto<GenderListDto>> GetAllGender();
        Task CreateGender(CreateGenderDto input);
        List<GenderListDto> GetAllList();
    }
}
