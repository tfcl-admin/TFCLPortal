using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.LoanSchedules.Dto;

namespace TFCLPortal.LoanSchedules
{
    public interface ILoanScheduleAppService : IApplicationService
    {
        LoanScheduleListDto GetLoanScheduleById(int Id);
        Task CreateLoanSchedule(CreateLoanScheduleDto input);
        Task<string> UpdateLoanSchedule(UpdateLoanScheduleDto input);
        List<LoanScheduleListDto> GetLoanScheduleList();
    }
}
