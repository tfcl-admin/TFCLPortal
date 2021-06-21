using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Holidays.Dto;

namespace TFCLPortal.Holidays
{
    public interface IHolidayAppService : IApplicationService
    {
        HolidayListDto GetHolidayById(int Id);
        Task<string> CreateHoliday(CreateHolidayDto input);
        Task<string> UpdateHoliday(UpdateHolidayDto input);
    }
}
