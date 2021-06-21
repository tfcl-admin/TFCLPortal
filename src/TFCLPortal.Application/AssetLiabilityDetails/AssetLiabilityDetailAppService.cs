using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.AssetLiabilityDetails.Dto;

namespace TFCLPortal.AssetLiabilityDetails
{
    public class AssetLiabilityDetailAppService : TFCLPortalAppServiceBase, IAssetLiabilityDetailAppService
    {
        private readonly IRepository<AssetLiabilityDetail, Int32> _assetLiabilityDetailRepository;
        private string AssetLiabilityDetails = "Asset Liability Detail";
        private readonly IApplicationAppService _applicationAppService;

        private readonly IApiCallLogAppService _apiCallLogAppService;
        public AssetLiabilityDetailAppService(IRepository<AssetLiabilityDetail, Int32> assetLiabilityDetailRepository, IApplicationAppService applicationAppService, IApiCallLogAppService apiCallLogAppService)
        {
            _assetLiabilityDetailRepository = assetLiabilityDetailRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
        }
        public async Task CreateAssetLiabilityDetail(CreateAssetLiabilityDetailDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateAssetLiabilityDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var isExistAssetLiability = _assetLiabilityDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if(isExistAssetLiability!=null)
                {
                    _assetLiabilityDetailRepository.Delete(isExistAssetLiability);
                }
                var assetLiabilityDetail = ObjectMapper.Map<AssetLiabilityDetail>(input);
                _assetLiabilityDetailRepository.Insert(assetLiabilityDetail);

                _applicationAppService.UpdateApplicationLastScreen("Asset Liability Detail", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", AssetLiabilityDetails));
            }
        }

        public async Task<AssetLiabilityDetailListDto> GetAssetLiabilityDetailById(int Id)
        {
            try
            {
                var assetLiabilityDetail = await _assetLiabilityDetailRepository.GetAsync(Id);

                return ObjectMapper.Map<AssetLiabilityDetailListDto>(assetLiabilityDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", AssetLiabilityDetails));
            }
        }

        public async Task<string> UpdateAssetLiabilityDetail(UpdateAssetLiabilityDetailDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var assetLiabilityDetail = _assetLiabilityDetailRepository.Get(input.Id);
                if (assetLiabilityDetail != null && assetLiabilityDetail.Id > 0)
                {
                    ObjectMapper.Map(input, assetLiabilityDetail);
                    await _assetLiabilityDetailRepository.UpdateAsync(assetLiabilityDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString ;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", AssetLiabilityDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", AssetLiabilityDetails));
            }
        }

        public async Task<AssetLiabilityDetailListDto> GetAssetLiabilityDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var assetLiabilityDetail = _assetLiabilityDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                return ObjectMapper.Map<AssetLiabilityDetailListDto>(assetLiabilityDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", AssetLiabilityDetails));
            }
        }
        public bool CheckAssetLiabilityDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var assetLiabilityDetail = _assetLiabilityDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (assetLiabilityDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", AssetLiabilityDetails));
            }
        }
    }
}
