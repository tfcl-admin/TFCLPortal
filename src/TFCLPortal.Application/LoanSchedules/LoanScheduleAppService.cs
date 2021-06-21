using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.LoanSchedules.Dto;

namespace TFCLPortal.LoanSchedules
{

    public class LoanScheduleAppService : TFCLPortalAppServiceBase, ILoanScheduleAppService
    {
        private readonly IRepository<LoanSchedule, Int32> _LoanScheduleRepository;
        private string Mcrc = "Loan Schedule";
        private readonly IApplicationAppService _applicationAppService;

        public LoanScheduleAppService(IRepository<LoanSchedule, Int32> LoanScheduleRepository, IApplicationAppService applicationAppService)
        {
            _LoanScheduleRepository = LoanScheduleRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateLoanSchedule(CreateLoanScheduleDto input)
        {
            try
            {
                var LoanSchedule = ObjectMapper.Map<LoanSchedule>(input);
                await _LoanScheduleRepository.InsertAsync(LoanSchedule);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", Mcrc));
            }
        }

        public LoanScheduleListDto GetLoanScheduleById(int Id)
        {
            try
            {
                var LoanSchedule = _LoanScheduleRepository.Get(Id);


                return ObjectMapper.Map<LoanScheduleListDto>(LoanSchedule);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Mcrc));
            }
        }

        public async Task<string> UpdateLoanSchedule(UpdateLoanScheduleDto input)
        {
            string ResponseString = "";
            try
            {
                var LoanSchedule = _LoanScheduleRepository.Get(input.Id);
                if (LoanSchedule != null && LoanSchedule.Id > 0)
                {
                    ObjectMapper.Map(input, LoanSchedule);
                    await _LoanScheduleRepository.UpdateAsync(LoanSchedule);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Mcrc));
            }
            return ResponseString;
        }
        public List<LoanScheduleListDto> GetLoanScheduleList()
        {
            try
            {
                var LoanSchedule = _LoanScheduleRepository.GetAllList().OrderByDescending(x => x.CreationTime);

                return ObjectMapper.Map<List<LoanScheduleListDto>>(LoanSchedule);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Mcrc));
            }
        }
    }
}
