using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.FundSources
{
    public interface IFundSourceAppService : IApplicationService
    {
        Task<ListResultDto<FundSourceListDto>> GetAllFundSource();
        Task CreateFundSource(CreateFundSourceDto input);
        List<FundSourceListDto> GetAllList();
    }
}
