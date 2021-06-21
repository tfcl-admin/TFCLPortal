using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ScheduleTemps.Dto;

namespace TFCLPortal.ScheduleTemps
{
    public interface IScheduleTempAppService : IApplicationService
    {
        Task<ScheduleTempListDto> GetScheduleTempById(int Id);
        Task<string> CreateScheduleTemp(CreateScheduleTempDto input);
        Task<string> UpdateScheduleTemp(UpdateScheduleTempDto input);
        Task<ScheduleTempListDto> GetScheduleTempByApplicationId(int ApplicationId);
        bool CheckScheduleTempByApplicationId(int ApplicationId);
        Task<List<ScheduleTempListDto>> GetScheduleTempList();
    }
}
