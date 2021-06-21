using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TFCLPortal.LoanAmortizations.Dto;

namespace TFCLPortal.LoanAmortizations
{
   public class LoanAmortizationAppService : TFCLPortalAppServiceBase,ILoanAmortizationAppService
    {
        private readonly IRepository<LoanAmortization, Int32> _loanAmortizationRepository;
        private string loanString = "Loan Amortization";

        public LoanAmortizationAppService(IRepository<LoanAmortization, Int32> loanAmortizationRepository)
        {
            _loanAmortizationRepository = loanAmortizationRepository;
        }

        public async Task CreateLoanAmortization(CreateLoanAmortizationDto input)
        {
            try
            {
               
                var loanAmortization = ObjectMapper.Map<LoanAmortization>(input);
                await _loanAmortizationRepository.InsertAsync(loanAmortization);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", loanString));
            }
        }

        public LoanAmortizationListDto GetLoanAmortizationByApplicationId(int ApplicationId)
        {
            try
            {
                var LoanAmortization = _loanAmortizationRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                return ObjectMapper.Map<LoanAmortizationListDto>(LoanAmortization);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", loanString));
            }
        }

        public Task<LoanAmortizationListDto> GetLoanAmortizationId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateLoanAmortization(UpdateLoanAmortizationDto input)
        {
            throw new NotImplementedException();
        }
    }
}
