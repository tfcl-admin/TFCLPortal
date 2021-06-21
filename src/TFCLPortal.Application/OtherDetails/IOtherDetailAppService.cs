using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.OtherDetails.Dto;

namespace TFCLPortal.OtherDetails
{
    public interface IOtherDetailAppService : IApplicationService
    {
        // Task<ListResultDto<QualificationListDto>> GetAllQualification();
        Task<OtherDetailListDto> GetOtherDetailById(int Id);
        Task CreateOtherDetail(CreateOtherDetailDto input);
        Task<string> UpdateOtherDetail(UpdateOtherDetailDto input);
        Task<OtherDetailListDto> GetOtherDetailByApplicationId(int ApplicationId);
    }
}
