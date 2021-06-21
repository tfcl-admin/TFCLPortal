using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TDSLoanEligibilities.Dto;

namespace TFCLPortal.TDSLoanEligibilities
{
   public interface ITDSLoanEligibilityAppService : IApplicationService
    {  

        Task<TDSLoanEligibilityListDto> GetTDSLoanEligibilityListById(int Id);
        Task CreateTDSLoanEligibility(CreateTDSLoanEligibilityDto input);
        Task<string> UpdateTDSLoanEligibilityDetail(UpdateTDSLoanEligibilityDto input);
        Task<TDSLoanEligibilityListDto> GetTDSLoanEligibilityListByApplicationId(int ApplicationId);

        bool CheckTDSLoanEligibilityListByApplicationId(int ApplicationId);
    }
}
