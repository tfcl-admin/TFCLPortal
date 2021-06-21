using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoanNatures
{
    public interface ILoanNatureAppService : IApplicationService
    {
        Task<ListResultDto<LoanNatureListDto>> GetAllLoanNatureAsync();
        List<LoanNatureListDto> GetAllList();
    }
}
