using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.TJSLoanEligibilities.Dto;

namespace TFCLPortal.TJSLoanEligibilities
{
    public class TJSLoanEligibilityAppService : TFCLPortalAppServiceBase, ITJSLoanEligibilityAppService
    {
        private readonly IRepository<TJSLoanEligibility, Int32> _TJSLoanEligibilityRepository;
        private string TJSLoanEligibilities = "TJS Loan Eligibility Detail"; 
        private readonly IApplicationAppService _applicationAppService;
        public TJSLoanEligibilityAppService(IRepository<TJSLoanEligibility, Int32> TJSLoanEligibilityRepository, IApplicationAppService applicationAppService)
        {
            _TJSLoanEligibilityRepository = TJSLoanEligibilityRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateTJSLoanEligibility(CreateTJSLoanEligibilityDto input)
        {
            try
            {
                var isExistTJSLoanEligibility = _TJSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (isExistTJSLoanEligibility != null)
                {
                    _TJSLoanEligibilityRepository.Delete(isExistTJSLoanEligibility);
                }

                var createTJSLoanEligibility = ObjectMapper.Map<TJSLoanEligibility>(input);
                await _TJSLoanEligibilityRepository.InsertAsync(createTJSLoanEligibility);

                _applicationAppService.UpdateApplicationLastScreen("Loan Eligibility", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", TJSLoanEligibilities));
            }
        }

        public async Task<TJSLoanEligibilityListDto> GetTJSLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var TJSLoanEligibilityDetail = _TJSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                return ObjectMapper.Map<TJSLoanEligibilityListDto>(TJSLoanEligibilityDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TJSLoanEligibilities));
            }
        }
        public bool CheckTJSLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var TJSLoanEligibilityDetail = _TJSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (TJSLoanEligibilityDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", TJSLoanEligibilities));
            }
        }
        public async Task<TJSLoanEligibilityListDto> GetTJSLoanEligibilityListById(int Id)
        {
            try
            {
                var TJSLoanEligibilityDetail = await _TJSLoanEligibilityRepository.GetAsync(Id);

                return ObjectMapper.Map<TJSLoanEligibilityListDto>(TJSLoanEligibilityDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TJSLoanEligibilities));
            }
        }

        public async Task<string> UpdateTJSLoanEligibilityDetail(UpdateTJSLoanEligibilityDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var updateTJSLoanEligibility = _TJSLoanEligibilityRepository.Get(input.Id);
                if (updateTJSLoanEligibility != null && updateTJSLoanEligibility.Id > 0)
                {
                    ObjectMapper.Map(input, updateTJSLoanEligibility);
                    await _TJSLoanEligibilityRepository.UpdateAsync(updateTJSLoanEligibility);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", TJSLoanEligibilities));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", TJSLoanEligibilities));
            }
        }
    }
}
