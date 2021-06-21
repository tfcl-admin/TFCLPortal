using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AssetLiabilityDetails.Dto;

namespace TFCLPortal.AssetLiabilityDetails
{
    public interface IAssetLiabilityDetailAppService : IApplicationService
    {
        Task<AssetLiabilityDetailListDto> GetAssetLiabilityDetailById(int Id);
        Task CreateAssetLiabilityDetail(CreateAssetLiabilityDetailDto input);
        Task<string> UpdateAssetLiabilityDetail(UpdateAssetLiabilityDetailDto input);
        Task<AssetLiabilityDetailListDto> GetAssetLiabilityDetailByApplicationId(int ApplicationId);
        bool CheckAssetLiabilityDetailByApplicationId(int ApplicationId);
    }
}
