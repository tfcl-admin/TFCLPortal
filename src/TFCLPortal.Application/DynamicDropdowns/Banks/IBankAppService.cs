using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Banks
{
    public interface IBankAppService : IApplicationService
    {
        List<BankListDto> GetAllList();
        Task<ListResultDto<BankListDto>> GetAllBanks();

    }
}
