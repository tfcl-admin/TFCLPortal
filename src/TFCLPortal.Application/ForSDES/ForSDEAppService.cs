using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.ForSDES.Dto;

namespace TFCLPortal.ForSDES
{
    public class ForSDEAppService : TFCLPortalAppServiceBase, IForSDEAppService
    {
        #region Properties
        private readonly IRepository<ForSDE, int> _forSDERepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IApplicationAppService _applicationAppService;

        #endregion
        #region Constructor 
        public ForSDEAppService(IRepository<ForSDE> forSDERepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _forSDERepository = forSDERepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _applicationAppService = applicationAppService;
            _referenceCheckRepository = referenceCheckRepository;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateForSDEInput createForSDEInput)
        {
            try
            {
                var isSdeRecommendation = _forSDERepository.GetAllList(x => x.ApplicationId == createForSDEInput.ApplicationId).SingleOrDefault();
                if (isSdeRecommendation != null)
                {
                    var SdeRecommendation = ObjectMapper.Map<ForSDE>(isSdeRecommendation);
                    _forSDERepository.Delete(SdeRecommendation);
                }
                var forSDE = ObjectMapper.Map<ForSDE>(createForSDEInput);
                await _forSDERepository.InsertAsync(forSDE);

                _applicationAppService.UpdateApplicationLastScreen("SDE Recommendations", createForSDEInput.ApplicationId);


            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<ForSDEListDto> GetForSDEById(int Id)
        {
            try
            {
                var forSDE = await _forSDERepository.GetAsync(Id);

                return ObjectMapper.Map<ForSDEListDto>(forSDE);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(EditForSDEInput editForSDEInput)
        {
            string ResponseString = "";
            try
            {


                var forSDE = _forSDERepository.Get(editForSDEInput.Id);
                if (forSDE != null && forSDE.Id > 0)
                {
                    ObjectMapper.Map(editForSDEInput, forSDE);
                    await _forSDERepository.UpdateAsync(forSDE);

                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "SDE"));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "SDE"));
            }
            return ResponseString;
        }

        public async Task<ForSDEListDto> GetForSDEByApplicationId(int ApplicationId)
        {
            try
            {
                var forSDE = _forSDERepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                var sde = ObjectMapper.Map<ForSDEListDto>(forSDE);

                if(sde!=null)
                {
                    if (sde.UtilityBillPaymentId != 0)
                    {
                        var utility = _utilityBillPayment.Get(sde.UtilityBillPaymentId);
                        sde.utilityName = utility.Name;
                    }

                    if (sde.referenceCheckId != 0)
                    {
                        var referenceCheck = _referenceCheckRepository.Get(sde.referenceCheckId);
                        sde.referenceCheckName = referenceCheck.Name;
                    }

                    if (sde.ApplicantReputationId != 0)
                    {
                        var ApplicantReputation = _applicantReputations.Get(sde.ApplicantReputationId);
                        sde.applicantReputationName = ApplicantReputation.Name;
                    }


                    //var initChat = (from forSde in _forSDERepository.GetAllList()
                    //                join utility in _utilityBillPayment.GetAllList() on forSde.UtilityBillPaymentId equals utility.Id
                    //                join check in _referenceCheckRepository.GetAllList() on forSde.referenceCheckId equals check.Id
                    //                join applicant in _applicantReputations.GetAllList() on forSde.ApplicantReputationId equals applicant.Id
                    //                where forSde.ApplicationId == ApplicationId
                    //                select new
                    //                {
                    //                    forSde,
                    //                    utilityName = utility.Name,
                    //                    referenceCheckName = check.Name,
                    //                    applicantReputationName = applicant.Name

                    //                }).FirstOrDefault();

                    //if (initChat != null)
                    //{
                    //    sde.utilityName = initChat.utilityName;
                    //    sde.referenceCheckName = initChat.referenceCheckName;
                    //    sde.applicantReputationName = initChat.applicantReputationName;
                    //}

                }
                
                return sde;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckForSDEByApplicationId(int ApplicationId)
        {
            try
            {
                var forSDE = _forSDERepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                if (forSDE != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "SDE"));
            }
        }
        #endregion
    }
}
