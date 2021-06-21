using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Holidays.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.Holidays
{
    public class HolidayAppService : TFCLPortalAppServiceBase, IHolidayAppService
    {
        private readonly IRepository<Holiday, Int32> _HolidayRepository;
        private string Holidays = "Holiday";
        public HolidayAppService(IRepository<Holiday, Int32> HolidayRepository)
        {
            _HolidayRepository = HolidayRepository;
        }

        public async Task<string> CreateHoliday(CreateHolidayDto input)
        {
            string ResponseString = "";

            try
            {
            
                var Holiday = ObjectMapper.Map<Holiday>(input);
                await _HolidayRepository.InsertAsync(Holiday);
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", Holidays));
            }
        }

        public  HolidayListDto GetHolidayById(int Id)
        {
            try
            {
                var Holiday =  _HolidayRepository.Get(Id);

                return ObjectMapper.Map<HolidayListDto>(Holiday);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Holidays));
            }
        }

        public async Task<string> UpdateHoliday(UpdateHolidayDto input)
        {
            string ResponseString = "";
            try
            {
                var Holiday = _HolidayRepository.Get(input.Id);
                if (Holiday != null && Holiday.Id > 0)
                {
                    ObjectMapper.Map(input, Holiday);
                    await _HolidayRepository.UpdateAsync(Holiday);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", Holidays));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Holidays));
            }
        }

    }
}
