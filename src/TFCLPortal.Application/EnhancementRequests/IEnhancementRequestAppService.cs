using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.EnhancementRequests.Dto;

namespace TFCLPortal.EnhancementRequests
{
    public interface IEnhancementRequestAppService : IApplicationService
    {
        Task<string> CreateEnhancementRequest(CreateEnhancementRequestDto input);
        //Task<string> MigrateEnhancementRequest(int ApplicationId);
        string SetEnhancementRequestState(int ApplicationId,int state);

        Task<EnhancementRequestListDto> GetEnhancementRequestById(int Id);
        Task<List<EnhancementRequestListDto>> GetAllEnhancementRequests();
        List<EnhancementRequestListDto> GetAllEnhancementRequestsBySdeId(int SDEID);
        Task<EnhancementRequestListDto> GetEnhancementRequestByApplicationId(int ApplicationId);
    }
}
