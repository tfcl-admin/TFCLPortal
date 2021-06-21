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
using TFCLPortal.SalaryDetails.Dto;
using TFCLPortal.BusinessNatures;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;
using TFCLPortal.DynamicDropdowns.BusinessNatures;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.DynamicDropdowns.ClientBusinessClassifications;
using TFCLPortal.DynamicDropdowns.LegalStatuses;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.DynamicDropdowns.SchoolLevels;
using TFCLPortal.DynamicDropdowns.SchoolTypes;
using TFCLPortal.DynamicDropdowns.StudentsGender;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.PersonalDetails;


namespace TFCLPortal.SalaryDetails
{
    public class SalaryDetailsAppService : TFCLPortalAppServiceBase, ISalaryDetailsAppService
    {
        private readonly IRepository<SalaryDetail, Int32> _SalaryDetailRepository;
        private readonly IRepository<SalaryDetailChild, Int32> _SalaryDetailChildrepository;
        private readonly IRepository<SchoolType> _schoolTyperepo;
        private readonly IRepository<BusinessLegalStatus> _businessLegalStatus;
        private readonly IRepository<OwnershipStatus> _ownershipStatusRepository;
        private readonly IRepository<ClientBusinessClassification> _clientBusinessClassificationRepository;
        private readonly IRepository<RentAgreementSignatory> _rentAgreementSignatoryRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<BusinessNature> _businessNatureRepository;
        private readonly IRepository<AcademicSession> _academicSessionRepository;
        private readonly IRepository<BusinessType> _businessTypeRepository;
        private readonly IRepository<SchoolLevel> _schoolLevelRepository;
        private readonly IRepository<LegalStatus> _legalStatusRepository;
        private readonly IRepository<SchoolCategory> _schoolCategoryRepository;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private string SalaryDetailss = "Business Detail";

        public SalaryDetailsAppService(IRepository<SalaryDetail, Int32> SalaryDetailRepository,
            IRepository<SalaryDetailChild, Int32> SalaryDetailChildrepository,
            IRepository<SchoolType> SchoolTyperepo,
            IRepository<BusinessLegalStatus> businessLegalStatus,
            IRepository<OwnershipStatus> ownershipStatusRepository,
            IApplicationAppService applicationAppService,
            IRepository<AcademicSession> academicSessionRepository,
            IRepository<BusinessType> businessTypeRepository,
            IRepository<SchoolLevel> schoolLevelRepository,
            IRepository<LegalStatus> legalStatusRepository,
            IRepository<SchoolCategory> schoolCategoryRepository,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<RentAgreementSignatory> rentAgreementSignatoryRepository,
            IRepository<ClientBusinessClassification> clientBusinessClassificationRepository,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IRepository<BusinessNature> businessNatureRepository
            )
        {
            _academicSessionRepository = academicSessionRepository;
            _schoolLevelRepository = schoolLevelRepository;
            _legalStatusRepository = legalStatusRepository;
            _schoolCategoryRepository = schoolCategoryRepository;
            _businessTypeRepository = businessTypeRepository;
            _SalaryDetailRepository = SalaryDetailRepository;
            _SalaryDetailChildrepository = SalaryDetailChildrepository;
            _schoolTyperepo = SchoolTyperepo;
            _businessLegalStatus = businessLegalStatus;
            _ownershipStatusRepository = ownershipStatusRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
            _businessNatureRepository = businessNatureRepository;
            _rentAgreementSignatoryRepository = rentAgreementSignatoryRepository;
            _clientBusinessClassificationRepository = clientBusinessClassificationRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }

        public async Task CreateSalaryDetail(CreateSalaryDetailDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateSalaryDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsSalaryDetailExist = _SalaryDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsSalaryDetailExist != null)
                {
                    var IsSalaryDetailChildExist = _SalaryDetailChildrepository.GetAllList().Where(x => x.Fk_SalaryDetailId == IsSalaryDetailExist.Id).ToList();
                    var SalaryDetail1 = ObjectMapper.Map<SalaryDetail>(IsSalaryDetailExist);
                    await _SalaryDetailRepository.DeleteAsync(SalaryDetail1);
                    var SalaryDetail = ObjectMapper.Map<SalaryDetail>(input);

                    var result = await _SalaryDetailRepository.InsertAsync(SalaryDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (IsSalaryDetailChildExist.Count > 0)
                    {
                        foreach (var scholBranch in IsSalaryDetailChildExist)
                        {
                            scholBranch.Fk_SalaryDetailId = result.Id;
                            var scholbrnchh = ObjectMapper.Map<SalaryDetailChild>(scholBranch);
                            await _SalaryDetailChildrepository.DeleteAsync(scholbrnchh);
                            CurrentUnitOfWork.SaveChanges();
                        }
                        List<CreateSalaryDetailChildDto> createSalaryDetailChildDtos = input.SalaryDetailList;
                        CurrentUnitOfWork.SaveChanges();
                        if (createSalaryDetailChildDtos.Count > 0)
                        {
                            foreach (var createSalaryDetailChildDto in createSalaryDetailChildDtos)
                            {
                                createSalaryDetailChildDto.Fk_SalaryDetailId = result.Id;
                                var SalaryDetailChild = ObjectMapper.Map<SalaryDetailChild>(createSalaryDetailChildDto);
                                await _SalaryDetailChildrepository.InsertAsync(SalaryDetailChild);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }
                    else
                    {
                        List<CreateSalaryDetailChildDto> createSalaryDetailChildDtos = input.SalaryDetailList;
                        CurrentUnitOfWork.SaveChanges();
                        if (createSalaryDetailChildDtos.Count > 0)
                        {
                            foreach (var createSalaryDetailChildDto in createSalaryDetailChildDtos)
                            {
                                createSalaryDetailChildDto.Fk_SalaryDetailId = result.Id;
                                var SalaryDetailChild = ObjectMapper.Map<SalaryDetailChild>(createSalaryDetailChildDto);
                                await _SalaryDetailChildrepository.InsertAsync(SalaryDetailChild);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }

                }
                else
                {
                    var SalaryDetail = ObjectMapper.Map<SalaryDetail>(input);

                    var result = await _SalaryDetailRepository.InsertAsync(SalaryDetail);

                    List<CreateSalaryDetailChildDto> createSalaryDetailChildDtos = input.SalaryDetailList;
                    CurrentUnitOfWork.SaveChanges();
                    if (createSalaryDetailChildDtos.Count > 0)
                    {
                        foreach (var createSalaryDetailChildDto in createSalaryDetailChildDtos)
                        {
                            createSalaryDetailChildDto.Fk_SalaryDetailId = result.Id;
                            var SalaryDetailChild = ObjectMapper.Map<SalaryDetailChild>(createSalaryDetailChildDto);
                            await _SalaryDetailChildrepository.InsertAsync(SalaryDetailChild);
                        }
                    }
                    CurrentUnitOfWork.SaveChanges();
                }
                _applicationAppService.UpdateApplicationLastScreen("BUSINESS DETAILS", input.ApplicationId);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", SalaryDetailss));
            }
        }

        public async Task<SalaryDetailDto> GetSalaryDetailById(int Id)
        {
            try
            {
                var SalaryDetail = await _SalaryDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<SalaryDetailDto>(SalaryDetail);
                var SalaryDetailChildes = await GetSalaryDetailChildes(Id);
                var MapSalaryDetailChild = ObjectMapper.Map<List<SalaryDetailChildDto>>(SalaryDetailChildes);
                result.SalaryDetailList = MapSalaryDetailChild;
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", SalaryDetailss));
            }
        }

        public async Task<List<SalaryDetailChild>> GetSalaryDetailChildes(int FK_SalaryDetailId)
        {
            try
            {
                return _SalaryDetailChildrepository.GetAllList(x => x.Fk_SalaryDetailId == FK_SalaryDetailId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateSalaryDetail(UpdateSalaryDetailDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var SalaryDetails = _SalaryDetailRepository.Get(input.Id);
                if (SalaryDetails != null && SalaryDetails.Id > 0)
                {
                    ObjectMapper.Map(input, SalaryDetails);

                    await _SalaryDetailRepository.UpdateAsync(SalaryDetails);
                    CurrentUnitOfWork.SaveChanges();

                    List<UpdateSalaryDetailChildDto> createSalaryDetailChildDtos = input.SalaryDetailList;
                    if (createSalaryDetailChildDtos.Count > 0)
                    {
                        foreach (var createSalaryDetailChildDto in createSalaryDetailChildDtos)
                        {
                            var SalaryDetailChild = _SalaryDetailChildrepository.Get(createSalaryDetailChildDto.Id);
                            if (SalaryDetailChild != null && SalaryDetailChild.Id > 0)
                            {
                                ObjectMapper.Map(createSalaryDetailChildDto, SalaryDetailChild);
                                await _SalaryDetailChildrepository.UpdateAsync(SalaryDetailChild);
                            }

                            CurrentUnitOfWork.SaveChanges();

                        }
                    }

                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", SalaryDetailss));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", SalaryDetailss));
            }
        }



        public async Task<SalaryDetailDto> GetSalaryDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getSalaryDetail = _SalaryDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var result = ObjectMapper.Map<SalaryDetailDto>(getSalaryDetail);
                if (result != null)
                {
                    var SalaryDetailChildes = await GetSalaryDetailChildes(result.Id);
                    var MapSalaryDetailChild = ObjectMapper.Map<List<SalaryDetailChildDto>>(SalaryDetailChildes);
                    result.SalaryDetailList = MapSalaryDetailChild;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", SalaryDetailss));
            }
        }

        public bool CheckSalaryDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getSalaryDetail = _SalaryDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (getSalaryDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", SalaryDetailss));
            }
        }

    }
}
