using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Schedules.Dto;

namespace TFCLPortal.Schedules
{
    public interface IScheduleAppService : IApplicationService
    {
        Task<ScheduleListDto> GetScheduleById(int Id);
        Task<string> CreateSchedule(CreateScheduleDto input);
        Task<string> UpdateSchedule(UpdateScheduleDto input);
        Task<ScheduleListDto> GetScheduleByApplicationId(int ApplicationId);

        Task<List<ScheduleInstallmenttListDto>> GetInstallmentPaymentsByUserId(int UserId);
        
        bool CheckScheduleByApplicationId(int ApplicationId);
        Task<List<ScheduleListDto>> GetScheduleList();
    }
}
