using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ExposureDetails.Dto;

namespace TFCLPortal.ExposureDetails
{
    public interface IExposureDetailAppService : IApplicationService
    {
        Task<ExposureDetailListDto> GetExposureDetailById(int Id);
        Task<string> CreateExposureDetail(CreateExposureDetailDto input);
        Task<string> UpdateExposureDetail(UpdateExposureDetailDto input);
        Task<ExposureDetailListDto> GetExposureDetailByApplicationId(int ApplicationId);
        bool CheckExposureDetailByApplicationId(int ApplicationId);
    }
}
