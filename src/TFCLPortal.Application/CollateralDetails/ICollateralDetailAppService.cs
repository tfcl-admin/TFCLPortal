using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.CollateralDetails.Dto;

namespace TFCLPortal.CollateralDetails
{
    public interface ICollateralDetailAppService : IApplicationService
    {
        Task<CollateralDetailListDto> GetCollateralDetailById(int Id);
        Task CreateCollateralDetail(CreateCollateralDetailDto input);
        Task<string> UpdateCollateralDetail(UpdateCollateralDetailDto input);
        Task<CollateralDetailListDto> GetCollateralDetailByApplicationId(int ApplicationId);

        bool CheckCollateralDetailByApplicationId(int ApplicationId);
    }
}
