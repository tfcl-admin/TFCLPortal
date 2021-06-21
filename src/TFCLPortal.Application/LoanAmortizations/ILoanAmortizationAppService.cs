using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.LoanAmortizations.Dto;

namespace TFCLPortal.LoanAmortizations
{
   public interface ILoanAmortizationAppService: IApplicationService
    {
        Task<LoanAmortizationListDto> GetLoanAmortizationId(int Id);
        Task CreateLoanAmortization(CreateLoanAmortizationDto input);
        Task<string> UpdateLoanAmortization(UpdateLoanAmortizationDto input);
        LoanAmortizationListDto GetLoanAmortizationByApplicationId(int ApplicationId);
    }
}
