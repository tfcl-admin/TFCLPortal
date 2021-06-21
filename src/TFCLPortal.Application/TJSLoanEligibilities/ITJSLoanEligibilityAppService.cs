using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TJSLoanEligibilities.Dto;

namespace TFCLPortal.TJSLoanEligibilities
{
   public interface ITJSLoanEligibilityAppService : IApplicationService
    {  

        Task<TJSLoanEligibilityListDto> GetTJSLoanEligibilityListById(int Id);
        Task CreateTJSLoanEligibility(CreateTJSLoanEligibilityDto input);
        Task<string> UpdateTJSLoanEligibilityDetail(UpdateTJSLoanEligibilityDto input);
        Task<TJSLoanEligibilityListDto> GetTJSLoanEligibilityListByApplicationId(int ApplicationId);
        bool CheckTJSLoanEligibilityListByApplicationId(int ApplicationId);
    }
}
