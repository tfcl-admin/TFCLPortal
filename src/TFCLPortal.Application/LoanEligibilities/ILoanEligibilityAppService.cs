using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.LoanEligibilities.Dto;

namespace TFCLPortal.LoanEligibilities
{
   public interface ILoanEligibilityAppService : IApplicationService
    {  

        Task<LoanEligibilityListDto> GetLoanEligibilityListById(int Id);
        Task CreateLoanEligibility(CreateLoanEligibilityDto input);
        Task<string> UpdateLoanEligibilityDetail(UpdateLoanEligibilityDto input);
        Task<LoanEligibilityListDto> GetLoanEligibilityListByApplicationId(int ApplicationId);

        bool CheckLoanEligibilityListByApplicationId(int ApplicationId);
    }
}
