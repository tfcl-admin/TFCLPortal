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
using TFCLPortal.Applications.Dto;
using TFCLPortal.DependentEducationDetails.Dto;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;
using TFCLPortal.DynamicDropdowns.BusinessNatures;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.DynamicDropdowns.ClientBusinessClassifications;
using TFCLPortal.DynamicDropdowns.Genders;
using TFCLPortal.DynamicDropdowns.LegalStatuses;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.DynamicDropdowns.SchoolLevels;
using TFCLPortal.DynamicDropdowns.SchoolTypes;
using TFCLPortal.DynamicDropdowns.StudentsGender;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.PersonalDetails;


namespace TFCLPortal.DependentEducationDetails
{
    public class DependentEducationDetailsAppService : TFCLPortalAppServiceBase, IDependentEducationDetailsAppService
    {
        private readonly IRepository<DependentEducationDetail, Int32> _DependentEducationDetailRepository;
        private readonly IRepository<DependentEducationDetailChild, Int32> _dependentEducationDetailChildrepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<PaymentFrequency> _paymentFrequencyRepository;
        private string DependentEducationDetailss = "Dependent Education Detail";

        public DependentEducationDetailsAppService(IRepository<DependentEducationDetail, Int32> DependentEducationDetailRepository,
            IRepository<DependentEducationDetailChild, Int32> DependentEducationDetailChildrepository,
            IApplicationAppService applicationAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<PaymentFrequency> paymentFrequencyRepository,
            IRepository<Gender> genderRepository)
        {
            _DependentEducationDetailRepository = DependentEducationDetailRepository;
            _dependentEducationDetailChildrepository = DependentEducationDetailChildrepository;
            _genderRepository = genderRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _paymentFrequencyRepository = paymentFrequencyRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateDependentEducationDetail(CreateDependentEducationDetailDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateDependentEducationDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsDependentEducationDetailExist = _DependentEducationDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsDependentEducationDetailExist != null)
                {
                    var IsDependentEducationDetailChildExist = _dependentEducationDetailChildrepository.GetAllList().Where(x => x.FK_DependentEducationId == IsDependentEducationDetailExist.Id).ToList();
                    var DependentEducationDetail1 = ObjectMapper.Map<DependentEducationDetail>(IsDependentEducationDetailExist);
                    await _DependentEducationDetailRepository.DeleteAsync(DependentEducationDetail1);
                    var DependentEducationDetail = ObjectMapper.Map<DependentEducationDetail>(input);

                    var result = await _DependentEducationDetailRepository.InsertAsync(DependentEducationDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (IsDependentEducationDetailChildExist.Count > 0)
                    {
                        foreach (var scholBranch in IsDependentEducationDetailChildExist)
                        {
                            scholBranch.FK_DependentEducationId = result.Id;
                            var scholbrnchh = ObjectMapper.Map<DependentEducationDetailChild>(scholBranch);
                            await _dependentEducationDetailChildrepository.DeleteAsync(scholbrnchh);
                            CurrentUnitOfWork.SaveChanges();
                        }
                        List<CreateDependentEducationDetailChildDto> createDependentEducationDetailChildDtos = input.dependentEducationDetailChild;
                        CurrentUnitOfWork.SaveChanges();
                        if (createDependentEducationDetailChildDtos.Count > 0)
                        {
                            foreach (var createDependentEducationDetailChildDto in createDependentEducationDetailChildDtos)
                            {
                                createDependentEducationDetailChildDto.FK_DependentEducationId = result.Id;
                                var DependentEducationDetailChild = ObjectMapper.Map<DependentEducationDetailChild>(createDependentEducationDetailChildDto);
                                await _dependentEducationDetailChildrepository.InsertAsync(DependentEducationDetailChild);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }
                    else
                    {
                        List<CreateDependentEducationDetailChildDto> createDependentEducationDetailChildDtos = input.dependentEducationDetailChild;
                        CurrentUnitOfWork.SaveChanges();
                        if (createDependentEducationDetailChildDtos.Count > 0)
                        {
                            foreach (var createDependentEducationDetailChildDto in createDependentEducationDetailChildDtos)
                            {
                                createDependentEducationDetailChildDto.FK_DependentEducationId = result.Id;
                                var DependentEducationDetailChild = ObjectMapper.Map<DependentEducationDetailChild>(createDependentEducationDetailChildDto);
                                await _dependentEducationDetailChildrepository.InsertAsync(DependentEducationDetailChild);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }

                }
                else
                {
                    var DependentEducationDetail = ObjectMapper.Map<DependentEducationDetail>(input);

                    var result = await _DependentEducationDetailRepository.InsertAsync(DependentEducationDetail);

                    List<CreateDependentEducationDetailChildDto> createDependentEducationDetailChildDtos = input.dependentEducationDetailChild;
                    CurrentUnitOfWork.SaveChanges();
                    if (createDependentEducationDetailChildDtos.Count > 0)
                    {
                        foreach (var createDependentEducationDetailChildDto in createDependentEducationDetailChildDtos)
                        {
                            createDependentEducationDetailChildDto.FK_DependentEducationId = result.Id;
                            var DependentEducationDetailChild = ObjectMapper.Map<DependentEducationDetailChild>(createDependentEducationDetailChildDto);
                            await _dependentEducationDetailChildrepository.InsertAsync(DependentEducationDetailChild);
                        }
                    }
                    CurrentUnitOfWork.SaveChanges();
                }
                _applicationAppService.UpdateApplicationLastScreen("Dependent Education DETAILS", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", DependentEducationDetailss));
            }
        }

        public async Task<DependentEducationDetailListDto> GetDependentEducationDetailById(int Id)
        {
            try
            {
                var DependentEducationDetail = await _DependentEducationDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<DependentEducationDetailListDto>(DependentEducationDetail);
                var DependentEducationDetailChildes = await GetDependentEducationDetailChilds(Id);
                var MapDependentEducationDetailChild = ObjectMapper.Map<List<DependentEducationDetailChildListDto>>(DependentEducationDetailChildes);
                result.dependentEducationDetailChild = MapDependentEducationDetailChild;
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", DependentEducationDetailss));
            }
        }

        public async Task<List<DependentEducationDetailChild>> GetDependentEducationDetailChilds(int FK_DependentEducationDetailId)
        {
            try
            {
                return _dependentEducationDetailChildrepository.GetAllList(x => x.FK_DependentEducationId == FK_DependentEducationDetailId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateDependentEducationDetail(UpdateDependentEducationDetailDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var DependentEducationDetails = _DependentEducationDetailRepository.Get(input.Id);
                if (DependentEducationDetails != null && DependentEducationDetails.Id > 0)
                {
                    ObjectMapper.Map(input, DependentEducationDetails);

                    await _DependentEducationDetailRepository.UpdateAsync(DependentEducationDetails);
                    CurrentUnitOfWork.SaveChanges();

                    List<CreateDependentEducationDetailChildDto> createDependentEducationDetailChildDtos = input.dependentEducationDetailChild;
                    if (createDependentEducationDetailChildDtos.Count > 0)
                    {
                        foreach (var createDependentEducationDetailChildDto in createDependentEducationDetailChildDtos)
                        {
                            var DependentEducationDetailChild = _dependentEducationDetailChildrepository.Get(createDependentEducationDetailChildDto.Id);
                            if (DependentEducationDetailChild != null && DependentEducationDetailChild.Id > 0)
                            {
                                ObjectMapper.Map(createDependentEducationDetailChildDto, DependentEducationDetailChild);
                                await _dependentEducationDetailChildrepository.UpdateAsync(DependentEducationDetailChild);
                            }

                            CurrentUnitOfWork.SaveChanges();

                        }
                    }

                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", DependentEducationDetailss));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", DependentEducationDetailss));
            }
        }



        public async Task<DependentEducationDetailListDto> GetDependentEducationDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getDependentEducationDetail = _DependentEducationDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var result = ObjectMapper.Map<DependentEducationDetailListDto>(getDependentEducationDetail);
                if (result != null)
                {
                    var DependentEducationDetailChildes = await GetDependentEducationDetailChilds(result.Id);
                    var MapDependentEducationDetailChild = ObjectMapper.Map<List<DependentEducationDetailChildListDto>>(DependentEducationDetailChildes);
                    result.dependentEducationDetailChild = MapDependentEducationDetailChild;

                    List<DependentEducationDetailChildListDto> schoolsList = new List<DependentEducationDetailChildListDto>();
                    if (MapDependentEducationDetailChild != null && MapDependentEducationDetailChild.Count > 0)
                    {
                        foreach (DependentEducationDetailChildListDto child in MapDependentEducationDetailChild)
                        {

                            if (child.Gender != 0)
                            {
                                var Gender = _genderRepository.GetAllList().Where(x => x.Id == child.Gender).FirstOrDefault();
                                child.GenderName = Gender.Name;
                            }
                            if (child.PaymentFrequency != 0)
                            {
                                var PaymentFrequency = _paymentFrequencyRepository.GetAllList().Where(x => x.Id == child.PaymentFrequency).FirstOrDefault();
                                child.PaymentFrequencyName = PaymentFrequency.Name;
                            }

                            schoolsList.Add(child);
                        }
                    }


                    result.dependentEducationDetailChild = schoolsList;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", DependentEducationDetailss));
            }
        }

        public bool CheckDependentEducationDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getDependentEducationDetail = _DependentEducationDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (getDependentEducationDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", DependentEducationDetailss));
            }
        }

     
    }
}
