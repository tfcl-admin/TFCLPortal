using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Mobilizations.Dto;

namespace TFCLPortal.Mobilizations
{
    public interface IMobilizationAppService : IApplicationService
    {
        List<GetMobilizationListDto> GetMobilizationById(int Id);
        Task<ApplicationResponse> CreateMobilization(CreateMobilizationDto input);
        Task<ApplicationResponse> UpdateMobilization(UpdateMobilizationDto input);
        MobilizationListDto GetMobilizationByApplicationId(int ApplicationId);
        List<GetMobilizationListDto> GetMobilizationList();
        List<GetMobilizationListDto> GetMobilizationListBySdeId(int SDE_ID);
        Task<ApplicationResponse> CreateMobilizationList(List<CreateMobilizationDto> input);
    }
}
