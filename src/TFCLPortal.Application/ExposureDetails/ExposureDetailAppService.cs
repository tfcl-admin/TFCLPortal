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
using TFCLPortal.Banks;
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.Banks;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.ExposureDetailChilds;
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.ExposureDetails
{
    public class ExposureDetailAppService : TFCLPortalAppServiceBase, IExposureDetailAppService
    {
        private readonly IRepository<ExposureDetail, Int32> _exposureDetailRepository;
        private readonly IRepository<ExposureDetailChild, Int32> _childRepository;
        private readonly IRepository<GuarantorDetail, Int32> _guarantorDetailAppService;
        private readonly IRepository<BusinessPlan, Int32> _BusinessPlanAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<Bank, Int32> _bankRepository;

        private string ExposureDetails = "Exposure Detail";
        public ExposureDetailAppService(IRepository<ExposureDetail, Int32> exposureDetailRepository,
            IRepository<GuarantorDetail, Int32> guarantorDetailAppService,
            IApplicationAppService applicationAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<BusinessPlan, Int32> BusinessPlanAppService,
            IRepository<Bank, Int32> bankRepository,
            IRepository<ExposureDetailChild, Int32> childRepository)
        {
            _exposureDetailRepository = exposureDetailRepository;
            _childRepository = childRepository;
            _guarantorDetailAppService = guarantorDetailAppService;
            _applicationAppService = applicationAppService;
            _BusinessPlanAppService = BusinessPlanAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _bankRepository = bankRepository;
        }

        public async Task<string> CreateExposureDetail(CreateExposureDetailDto input)
        {
            CreateApiCallLogDto callLog = new CreateApiCallLogDto();
            callLog.FunctionName = "CreateExposureDetail";
            callLog.Input = JsonConvert.SerializeObject(input);
            var returnStr = _apiCallLogAppService.CreateApplication(callLog);

            string response = "Success";
            var IsexposureDetailExist = _exposureDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
            try
            {
                if (IsexposureDetailExist != null)
                {
                    var IsExposureChildExist = _childRepository.GetAllList().Where(x => x.Fk_ExpoDetailID == IsexposureDetailExist.Id).ToList();
                    var exposureDetail1 = ObjectMapper.Map<ExposureDetail>(IsexposureDetailExist);
                    await _exposureDetailRepository.DeleteAsync(exposureDetail1);
                    var exposureDetail = ObjectMapper.Map<ExposureDetail>(input);
                    var result = await _exposureDetailRepository.InsertAsync(exposureDetail);
                    await CurrentUnitOfWork.SaveChangesAsync();
                    if (IsExposureChildExist.Count > 0)
                    {
                        foreach (var child in IsExposureChildExist)
                        {
                            //child.Fk_ExpoDetailID = result.Id;
                            var expoChild = ObjectMapper.Map<ExposureDetailChild>(child);
                            await _childRepository.DeleteAsync(expoChild);
                            await CurrentUnitOfWork.SaveChangesAsync();
                        }
                        List<UpdateExposureChildDto> exposureDetailAddDtos = input.exposureDetailsList;
                        foreach (var exposureDetailAddDto in exposureDetailAddDtos)
                        {
                            exposureDetailAddDto.Fk_ExpoDetailID = result.Id;
                            var exposureDetailchild = ObjectMapper.Map<ExposureDetailChild>(exposureDetailAddDto);
                            await _childRepository.InsertAsync(exposureDetailchild);
                            await CurrentUnitOfWork.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        List<UpdateExposureChildDto> exposureDetailAddDtos = input.exposureDetailsList;
                        if (exposureDetailAddDtos.Count > 0)
                        {
                            foreach (var exposureDetailAddDto in exposureDetailAddDtos)
                            {
                                exposureDetailAddDto.Fk_ExpoDetailID = result.Id;
                                var exposureDetailchild = ObjectMapper.Map<ExposureDetailChild>(exposureDetailAddDto);
                                await _childRepository.InsertAsync(exposureDetailchild);
                                await CurrentUnitOfWork.SaveChangesAsync();
                            }
                        }
                        await CurrentUnitOfWork.SaveChangesAsync();
                    }

                }
                else
                {
                    var exposureDetail = ObjectMapper.Map<ExposureDetail>(input);

                    var result = await _exposureDetailRepository.InsertAsync(exposureDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (input.exposureDetailsList.Count > 0)
                    {
                        List<UpdateExposureChildDto> exposureDetailAddDtos = input.exposureDetailsList;
                        foreach (var exposureDetailAddDto in exposureDetailAddDtos)
                        {
                            exposureDetailAddDto.Fk_ExpoDetailID = result.Id;
                            var exposureDetailchild = ObjectMapper.Map<ExposureDetailChild>(exposureDetailAddDto);
                            await _childRepository.InsertAsync(exposureDetailchild);
                            await CurrentUnitOfWork.SaveChangesAsync();
                        }
                    }
                }
                _applicationAppService.UpdateApplicationLastScreen("Exposure DETAILS", input.ApplicationId);

                return response;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", ExposureDetails));

            }


        }
        public async Task<ExposureDetailListDto> GetExposureDetailById(int Id)
        {
            try
            {
                var exposureDetail = await _exposureDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<ExposureDetailListDto>(exposureDetail);
                if (result != null)
                {
                    var ExposureChild = _childRepository.GetAllList(i => i.Fk_ExpoDetailID == Id);
                    var MapexposureDetailAddDto = ObjectMapper.Map<List<ExposureDetailChildListDto>>(ExposureChild);
                    result.exposureDetailsList = MapexposureDetailAddDto;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ExposureDetails));
            }
        }
        public async Task<string> UpdateExposureDetail(UpdateExposureDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var exposureDetail = _exposureDetailRepository.Get(input.Id);
                if (exposureDetail != null && exposureDetail.Id > 0)
                {
                    ObjectMapper.Map(input, exposureDetail);
                    await _exposureDetailRepository.UpdateAsync(exposureDetail);
                    CurrentUnitOfWork.SaveChanges();

                    if (input.exposureDetailsList.Count > 0)
                    {
                        foreach (var child in input.exposureDetailsList)
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
                    throw new UserFriendlyException(L("UpdateMethodError{0}", ExposureDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", ExposureDetails));
            }
        }
        public async Task<ExposureDetailListDto> GetExposureDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var exposureDetail = _exposureDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var result = ObjectMapper.Map<ExposureDetailListDto>(exposureDetail);
                if (result != null)
                {
                    var ExposureChild = _childRepository.GetAllList(i => i.Fk_ExpoDetailID == result.Id);
                    var MapexposureDetailAddDto = ObjectMapper.Map<List<ExposureDetailChildListDto>>(ExposureChild);

                    if (MapexposureDetailAddDto.Count > 0)
                    {
                        foreach (var child in MapexposureDetailAddDto)
                        {
                            if(child.BankName!=null && child.BankName!=0)
                            {
                                child.BankNameString = _bankRepository.Get((int)child.BankName).Name;
                            }
                        }
                    }

                    result.exposureDetailsList = MapexposureDetailAddDto;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ExposureDetails));
            }
        }
        public bool CheckExposureDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var exposureDetail = _exposureDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                if (exposureDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", ExposureDetails));
            }
        }
    }
}
