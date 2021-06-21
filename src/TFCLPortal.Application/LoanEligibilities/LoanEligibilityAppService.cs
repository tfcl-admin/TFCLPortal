using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.LoanEligibilities.Dto;

namespace TFCLPortal.LoanEligibilities
{
    public class LoanEligibilityAppService : TFCLPortalAppServiceBase, ILoanEligibilityAppService
    {
        private readonly IRepository<LoanEligibility, Int32> _loanEligibilityRepository;
        private string loanEligibilities = "Loan Eligibility Detail"; 
        private readonly IApplicationAppService _applicationAppService;
        public LoanEligibilityAppService(IRepository<LoanEligibility, Int32> loanEligibilityRepository, IApplicationAppService applicationAppService)
        {
            _loanEligibilityRepository = loanEligibilityRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateLoanEligibility(CreateLoanEligibilityDto input)
        {
            try
            {
                var isExistLoanEligibility = _loanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (isExistLoanEligibility != null)
                {
                    _loanEligibilityRepository.Delete(isExistLoanEligibility);
                }

                var createLoanEligibility = ObjectMapper.Map<LoanEligibility>(input);
                await _loanEligibilityRepository.InsertAsync(createLoanEligibility);

                _applicationAppService.UpdateApplicationLastScreen("Loan Eligibility", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", loanEligibilities));
            }
        }

        public async Task<LoanEligibilityListDto> GetLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var LoanEligibilityDetail = _loanEligibilityRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                return ObjectMapper.Map<LoanEligibilityListDto>(LoanEligibilityDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", loanEligibilities));
            }
        }
        public bool CheckLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var LoanEligibilityDetail = _loanEligibilityRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                if (LoanEligibilityDetail != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", loanEligibilities));
            }
        }
        public async Task<LoanEligibilityListDto> GetLoanEligibilityListById(int Id)
        {
            try
            {
                var LoanEligibilityDetail = await _loanEligibilityRepository.GetAsync(Id);

                return ObjectMapper.Map<LoanEligibilityListDto>(LoanEligibilityDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", loanEligibilities));
            }
        }

        public async Task<string> UpdateLoanEligibilityDetail(UpdateLoanEligibilityDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var updateLoanEligibility = _loanEligibilityRepository.Get(input.Id);
                if (updateLoanEligibility != null && updateLoanEligibility.Id > 0)
                {
                    ObjectMapper.Map(input, updateLoanEligibility);
                    await _loanEligibilityRepository.UpdateAsync(updateLoanEligibility);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", loanEligibilities));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", loanEligibilities));
            }
        }
    }
}
