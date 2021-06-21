using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
//NEW DROPDOWN API Addition Class APP Service Interface
namespace TFCLPortal.DynamicDropdowns.RespondantDesignations
{
    public interface IRespondantDesignationAppService : IApplicationService
    {
        List<RespondantDesignationListDto> GetAllList();
        Task<ListResultDto<RespondantDesignationListDto>> GetAllRespondantDesignations();

    }
}