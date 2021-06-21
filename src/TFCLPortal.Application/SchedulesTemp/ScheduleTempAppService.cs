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
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.ScheduleTemps.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.ScheduleInstallmentTemps;

namespace TFCLPortal.ScheduleTemps
{
    public class ScheduleTempAppService : TFCLPortalAppServiceBase, IScheduleTempAppService
    {
        private readonly IRepository<ScheduleTemp, Int32> _ScheduleTempRepository;
        private readonly IRepository<ScheduleInstallmentTemp, Int32> _childRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;

        private string ScheduleTemps = "Schedules Temp";
        public ScheduleTempAppService(IRepository<ScheduleTemp, Int32> ScheduleTempRepository,
            IRepository<GuarantorDetail, Int32> guarantorDetailAppService,
            IApplicationAppService applicationAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<BusinessPlan, Int32> BusinessPlanAppService,
            IRepository<ScheduleInstallmentTemp, Int32> childRepository)
        {
            _ScheduleTempRepository = ScheduleTempRepository;
            _childRepository = childRepository;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
        }

        public async Task<string> CreateScheduleTemp(CreateScheduleTempDto input)
        {
            CreateApiCallLogDto callLog = new CreateApiCallLogDto();
            callLog.FunctionName = "CreateScheduleTemp";
            callLog.Input = JsonConvert.SerializeObject(input);
            var returnStr = _apiCallLogAppService.CreateApplication(callLog);

            string response = "Success";
            var IsScheduleTempExist = _ScheduleTempRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
            try
            {
                if (IsScheduleTempExist != null)
                {
                    var IsScheduleInstallmentTempExist = _childRepository.GetAllList().Where(x => x.FK_ScheduleId == IsScheduleTempExist.Id).ToList();

                    var Schedule1 = ObjectMapper.Map<ScheduleTemp>(IsScheduleTempExist);
                    await _ScheduleTempRepository.DeleteAsync(Schedule1);

                    var Schedule = ObjectMapper.Map<ScheduleTemp>(input);
                    var result = await _ScheduleTempRepository.InsertAsync(Schedule);
                    CurrentUnitOfWork.SaveChanges();

                    if (IsScheduleInstallmentTempExist.Count > 0)
                    {
                        foreach (var child in IsScheduleInstallmentTempExist)
                        {
                            child.FK_ScheduleId = result.Id;
                            var installment = ObjectMapper.Map<ScheduleInstallmentTemp>(child);
                            await _childRepository.DeleteAsync(installment);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        List<CreateScheduleTempInstallmentDto> ScheduleTempAddDtos = input.installmentList;
                        foreach (var ScheduleTempAddDto in ScheduleTempAddDtos)
                        {
                            ScheduleTempAddDto.FK_ScheduleId = result.Id;
                            var ScheduleInstallment = ObjectMapper.Map<ScheduleInstallmentTemp>(ScheduleTempAddDto);
                            await _childRepository.InsertAsync(ScheduleInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    else
                    {
                        List<CreateScheduleTempInstallmentDto> ScheduleTempAddDtos = input.installmentList;
                        foreach (var ScheduleTempAddDto in ScheduleTempAddDtos)
                        {
                            ScheduleTempAddDto.FK_ScheduleId = result.Id;
                            var ScheduleTempInstallment = ObjectMapper.Map<ScheduleInstallmentTemp>(ScheduleTempAddDto);
                            await _childRepository.InsertAsync(ScheduleTempInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                }
                else
                {
                    var Schedule = ObjectMapper.Map<ScheduleTemp>(input);
                    
                    var result = await _ScheduleTempRepository.InsertAsync(Schedule);
                    CurrentUnitOfWork.SaveChanges();
                    if (input.installmentList.Count > 0)
                    {
                        List<CreateScheduleTempInstallmentDto> ScheduleTempAddDtos = input.installmentList;
                        foreach (var ScheduleTempAddDto in ScheduleTempAddDtos)
                        {
                            ScheduleTempAddDto.FK_ScheduleId = result.Id;
                            var ScheduleTempInstallment = ObjectMapper.Map<ScheduleInstallmentTemp>(ScheduleTempAddDto);
                            await _childRepository.InsertAsync(ScheduleTempInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", ScheduleTemps));

            }


        }
        public async Task<ScheduleTempListDto> GetScheduleTempById(int Id)
        {
            try
            {
                var ScheduleTemp = await _ScheduleTempRepository.GetAsync(Id);
                var result = ObjectMapper.Map<ScheduleTempListDto>(ScheduleTemp);
                if (result != null)
                {
                    var ScheduleTempInstallment = _childRepository.GetAllList(i => i.FK_ScheduleId == Id);
                    var MapScheduleTempAddDto = ObjectMapper.Map<List<ScheduleInstallmenttTempListDto>>(ScheduleTempInstallment);
                    result.installmentList = MapScheduleTempAddDto;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ScheduleTemps));
            }
        }
        public async Task<string> UpdateScheduleTemp(UpdateScheduleTempDto input)
        {
            string ResponseString = "";
            try
            {
                var ScheduleTemp = _ScheduleTempRepository.Get(input.Id);
                if (ScheduleTemp != null && ScheduleTemp.Id > 0)
                {
                    ObjectMapper.Map(input, ScheduleTemp);
                    await _ScheduleTempRepository.UpdateAsync(ScheduleTemp);
                    CurrentUnitOfWork.SaveChanges();

                    if (input.installmentList.Count > 0)
                    {
                        foreach (var child in input.installmentList)
                        {
                            var detailChild = _childRepository.Get(child.Id);
                            ObjectMapper.Map(child, detailChild);
                            await _childRepository.UpdateAsync(detailChild);
                            CurrentUnitOfWork.SaveChanges();

                        }
                    }
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", ScheduleTemps));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", ScheduleTemps));
            }
        }
        public async Task<ScheduleTempListDto> GetScheduleTempByApplicationId(int ApplicationId)
        {
            try
            {
                var Schedule = _ScheduleTempRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var result = ObjectMapper.Map<ScheduleTempListDto>(Schedule);
                if (result != null)
                {
                    var ScheduleTempInstallment = _childRepository.GetAllList(i => i.FK_ScheduleId == result.Id);
                    var MapScheduleTempAddDto = ObjectMapper.Map<List<ScheduleInstallmenttTempListDto>>(ScheduleTempInstallment);
                    result.installmentList = MapScheduleTempAddDto;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ScheduleTemps));
            }
        }

        public async Task<List<ScheduleTempListDto>> GetScheduleTempList()
        {
            try
            {
                var Schedule = _ScheduleTempRepository.GetAllList().ToList();

                return ObjectMapper.Map<List<ScheduleTempListDto>>(Schedule);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ScheduleTemps));
            }
        }

        public bool CheckScheduleTempByApplicationId(int ApplicationId)
        {
            try
            {
                var Schedule = _ScheduleTempRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (Schedule != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ScheduleTemps));
            }
        }
    }
}
