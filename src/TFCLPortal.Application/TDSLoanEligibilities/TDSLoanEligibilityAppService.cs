using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.TDSLoanEligibilities.Dto;

namespace TFCLPortal.TDSLoanEligibilities
{
    public class TDSLoanEligibilityAppService : TFCLPortalAppServiceBase, ITDSLoanEligibilityAppService
    {
        private readonly IRepository<TDSLoanEligibility, Int32> _TDSLoanEligibilityRepository;
        private string TDSLoanEligibilities = "TDS Loan Eligibility Detail"; 
        private readonly IApplicationAppService _applicationAppService;
        public TDSLoanEligibilityAppService(IRepository<TDSLoanEligibility, Int32> TDSLoanEligibilityRepository, IApplicationAppService applicationAppService)
        {
            _TDSLoanEligibilityRepository = TDSLoanEligibilityRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateTDSLoanEligibility(CreateTDSLoanEligibilityDto input)
        {
            try
            {
                var isExistTDSLoanEligibility = _TDSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (isExistTDSLoanEligibility != null)
                {
                    _TDSLoanEligibilityRepository.Delete(isExistTDSLoanEligibility);
                }

                var createTDSLoanEligibility = ObjectMapper.Map<TDSLoanEligibility>(input);
                await _TDSLoanEligibilityRepository.InsertAsync(createTDSLoanEligibility);

                _applicationAppService.UpdateApplicationLastScreen("Loan Eligibility", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", TDSLoanEligibilities));
            }
        }

        public async Task<TDSLoanEligibilityListDto> GetTDSLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var TDSLoanEligibilityDetail = _TDSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                return ObjectMapper.Map<TDSLoanEligibilityListDto>(TDSLoanEligibilityDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TDSLoanEligibilities));
            }
        }
        public bool CheckTDSLoanEligibilityListByApplicationId(int ApplicationId)
        {
            try
            {
                var TDSLoanEligibilityDetail = _TDSLoanEligibilityRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (TDSLoanEligibilityDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", TDSLoanEligibilities));
            }
        }
        public async Task<TDSLoanEligibilityListDto> GetTDSLoanEligibilityListById(int Id)
        {
            try
            {
                var TDSLoanEligibilityDetail = await _TDSLoanEligibilityRepository.GetAsync(Id);

                return ObjectMapper.Map<TDSLoanEligibilityListDto>(TDSLoanEligibilityDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TDSLoanEligibilities));
            }
        }

        public async Task<string> UpdateTDSLoanEligibilityDetail(UpdateTDSLoanEligibilityDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var updateTDSLoanEligibility = _TDSLoanEligibilityRepository.Get(input.Id);
                if (updateTDSLoanEligibility != null && updateTDSLoanEligibility.Id > 0)
                {
                    ObjectMapper.Map(input, updateTDSLoanEligibility);
                    await _TDSLoanEligibilityRepository.UpdateAsync(updateTDSLoanEligibility);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", TDSLoanEligibilities));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", TDSLoanEligibilities));
            }
        }
    }
}
