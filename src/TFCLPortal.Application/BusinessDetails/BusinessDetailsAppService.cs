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
using TFCLPortal.BusinessDetails.Dto;
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


namespace TFCLPortal.BusinessDetails
{
    public class BusinessDetailsAppService : TFCLPortalAppServiceBase, IBusinessDetailsAppService
    {
        private readonly IRepository<BusinessDetail, Int32> _businessDetailRepository;
        private readonly IRepository<School_Branch, Int32> _schoolBranchrepository;
        private readonly IRepository<SchoolType> _schoolTyperepo;
        private readonly IRepository<BusinessLegalStatus> _businessLegalStatus;
        private readonly IRepository<OwnershipStatus> _ownershipStatusRepository;
        private readonly IRepository<ClientBusinessClassification> _clientBusinessClassificationRepository;
        private readonly IRepository<RentAgreementSignatory> _rentAgreementSignatoryRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        //private readonly IRentAgreementSignatoryAppService _rentAgreementSignatoryAppService;
        //private readonly IBusinessNatureAppService _businessNatureAppService;
        private readonly IRepository<BusinessNature> _businessNatureRepository;

        //private readonly IClientBusinessClassificationAppService _clientBusinessClassificationAppService;
        //private readonly IAcademicSessionAppService _academicSessionAppService;
        private readonly IRepository<AcademicSession> _academicSessionRepository;

        //private readonly IBusinessTypeAppService _businessTypeAppService;
        private readonly IRepository<BusinessType> _businessTypeRepository;

        //private readonly ISchoolLevelAppService _schoolLevelAppService;
        private readonly IRepository<SchoolLevel> _schoolLevelRepository;

        //private readonly ILegalStatusAppService _legalStatusAppService;
        private readonly IRepository<LegalStatus> _legalStatusRepository;

        //private readonly ISchoolCategoryAppService _schoolCategoryAppService;
        private readonly IRepository<SchoolCategory> _schoolCategoryRepository;

        //private readonly IRepository<StudentGender> _studentGenderRepository;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private string businessDetailss = "Business Detail";

        public BusinessDetailsAppService(IRepository<BusinessDetail, Int32> businessDetailRepository,
            IRepository<School_Branch, Int32> schoolBranchrepository,
            IRepository<SchoolType> SchoolTyperepo,
            IRepository<BusinessLegalStatus> businessLegalStatus,
            IRepository<OwnershipStatus> ownershipStatusRepository,
            IApplicationAppService applicationAppService,
            IRepository<AcademicSession> academicSessionRepository,
            IRepository<BusinessType> businessTypeRepository,
            IRepository<SchoolLevel> schoolLevelRepository,
            IRepository<LegalStatus> legalStatusRepository,
            IRepository<SchoolCategory> schoolCategoryRepository,
            //IBusinessNatureAppService businessNatureAppService,
            //IClientBusinessClassificationAppService clientBusinessClassificationAppService,
            //IRentAgreementSignatoryAppService rentAgreementSignatoryAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<RentAgreementSignatory> rentAgreementSignatoryRepository,
            //ISchoolLevelAppService schoolLevelAppService,
            //ILegalStatusAppService legalStatusAppService,
            IRepository<ClientBusinessClassification> clientBusinessClassificationRepository,
            //IBusinessTypeAppService businessTypeAppService,
            //ISchoolCategoryAppService schoolCategoryAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            //IAcademicSessionAppService academicSessionAppService,
            //IRepository<StudentGender> studentGenderRepository
            IRepository<BusinessNature> businessNatureRepository
            )
        {
            _academicSessionRepository = academicSessionRepository;
            _schoolLevelRepository = schoolLevelRepository;
            _legalStatusRepository = legalStatusRepository;
            _schoolCategoryRepository = schoolCategoryRepository;
            _businessTypeRepository = businessTypeRepository;
            _businessDetailRepository = businessDetailRepository;
            _schoolBranchrepository = schoolBranchrepository;
            _schoolTyperepo = SchoolTyperepo;
            _businessLegalStatus = businessLegalStatus;
            _ownershipStatusRepository = ownershipStatusRepository;
            //_studentGenderRepository = studentGenderRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
            //_businessNatureAppService = businessNatureAppService;
            _businessNatureRepository = businessNatureRepository;
            //_clientBusinessClassificationAppService = clientBusinessClassificationAppService;
            //_rentAgreementSignatoryAppService = rentAgreementSignatoryAppService;
            _rentAgreementSignatoryRepository = rentAgreementSignatoryRepository;
            //_academicSessionAppService = academicSessionAppService;
            //_schoolCategoryAppService = schoolCategoryAppService;
            //_businessTypeAppService = businessTypeAppService;
            _clientBusinessClassificationRepository = clientBusinessClassificationRepository;
            //_schoolLevelAppService = schoolLevelAppService;
            //_legalStatusAppService = legalStatusAppService;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }

        public async Task CreateBusinessDetail(CreateBusinessDetailDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateBusinessDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsbusinessDetailExist = _businessDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsbusinessDetailExist != null)
                {
                    var IsSchoolBranchExist = _schoolBranchrepository.GetAllList().Where(x => x.Fk_BusinessDetailID == IsbusinessDetailExist.Id).ToList();
                    var businessDetail1 = ObjectMapper.Map<BusinessDetail>(IsbusinessDetailExist);
                    await _businessDetailRepository.DeleteAsync(businessDetail1);
                    var businessDetail = ObjectMapper.Map<BusinessDetail>(input);

                    var result = await _businessDetailRepository.InsertAsync(businessDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (IsSchoolBranchExist.Count > 0)
                    {
                        foreach (var scholBranch in IsSchoolBranchExist)
                        {
                            scholBranch.Fk_BusinessDetailID = result.Id;
                            var scholbrnchh = ObjectMapper.Map<School_Branch>(scholBranch);
                            await _schoolBranchrepository.DeleteAsync(scholbrnchh);
                            CurrentUnitOfWork.SaveChanges();
                        }
                        List<CreateSchoolBranchDto> createSchoolBranchDtos = input.school_Branches;
                        CurrentUnitOfWork.SaveChanges();
                        if (createSchoolBranchDtos.Count > 0)
                        {
                            foreach (var createSchoolBranchDto in createSchoolBranchDtos)
                            {
                                createSchoolBranchDto.Fk_BusinessDetailID = result.Id;
                                var schoolBranch = ObjectMapper.Map<School_Branch>(createSchoolBranchDto);
                                await _schoolBranchrepository.InsertAsync(schoolBranch);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }
                    else
                    {
                        List<CreateSchoolBranchDto> createSchoolBranchDtos = input.school_Branches;
                        CurrentUnitOfWork.SaveChanges();
                        if (createSchoolBranchDtos.Count > 0)
                        {
                            foreach (var createSchoolBranchDto in createSchoolBranchDtos)
                            {
                                createSchoolBranchDto.Fk_BusinessDetailID = result.Id;
                                var schoolBranch = ObjectMapper.Map<School_Branch>(createSchoolBranchDto);
                                await _schoolBranchrepository.InsertAsync(schoolBranch);
                            }
                        }
                        CurrentUnitOfWork.SaveChanges();
                    }

                }
                else
                {
                    var businessDetail = ObjectMapper.Map<BusinessDetail>(input);

                    var result = await _businessDetailRepository.InsertAsync(businessDetail);

                    List<CreateSchoolBranchDto> createSchoolBranchDtos = input.school_Branches;
                    CurrentUnitOfWork.SaveChanges();
                    if (createSchoolBranchDtos.Count > 0)
                    {
                        foreach (var createSchoolBranchDto in createSchoolBranchDtos)
                        {
                            createSchoolBranchDto.Fk_BusinessDetailID = result.Id;
                            var schoolBranch = ObjectMapper.Map<School_Branch>(createSchoolBranchDto);
                            await _schoolBranchrepository.InsertAsync(schoolBranch);
                        }
                    }
                    CurrentUnitOfWork.SaveChanges();
                }
                _applicationAppService.UpdateApplicationLastScreen("BUSINESS DETAILS", input.ApplicationId);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", businessDetailss));
            }
        }

        public async Task<BusinessDetailDto> GetBusinessDetailById(int Id)
        {
            try
            {
                var businessDetail = await _businessDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<BusinessDetailDto>(businessDetail);
                var schoolBranches = await GetSchoolBranches(Id);
                var MapSchoolBranch = ObjectMapper.Map<List<SchoolBranchDto>>(schoolBranches);
                result.school_Branches = MapSchoolBranch;
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", businessDetailss));
            }
        }

        public async Task<List<School_Branch>> GetSchoolBranches(int FK_BusinessDetailId)
        {
            try
            {
                return _schoolBranchrepository.GetAllList(x => x.Fk_BusinessDetailID == FK_BusinessDetailId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateBusinessDetail(UpdateBusinessDetailDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var businessDetails = _businessDetailRepository.Get(input.Id);
                if (businessDetails != null && businessDetails.Id > 0)
                {
                    ObjectMapper.Map(input, businessDetails);

                    await _businessDetailRepository.UpdateAsync(businessDetails);
                    CurrentUnitOfWork.SaveChanges();

                    List<UpdateSchoolBranchDto> createSchoolBranchDtos = input.school_Branches;
                    if (createSchoolBranchDtos.Count > 0)
                    {
                        foreach (var createSchoolBranchDto in createSchoolBranchDtos)
                        {
                            var schoolBranch = _schoolBranchrepository.Get(createSchoolBranchDto.Id);
                            if (schoolBranch != null && schoolBranch.Id > 0)
                            {
                                ObjectMapper.Map(createSchoolBranchDto, schoolBranch);
                                await _schoolBranchrepository.UpdateAsync(schoolBranch);
                            }

                            CurrentUnitOfWork.SaveChanges();

                        }
                    }

                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", businessDetailss));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", businessDetailss));
            }
        }



        public async Task<BusinessDetailDto> GetBusinessDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getbusinessdetail = _businessDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var result = ObjectMapper.Map<BusinessDetailDto>(getbusinessdetail);
                if (result != null)
                {
                    var schoolBranches = await GetSchoolBranches(result.Id);
                    var MapSchoolBranch = ObjectMapper.Map<List<SchoolBranchDto>>(schoolBranches);
                    result.school_Branches = MapSchoolBranch;

                    List<SchoolBranchDto> schoolsList = new List<SchoolBranchDto>();
                    if (MapSchoolBranch != null && MapSchoolBranch.Count > 0)
                    {
                        foreach (SchoolBranchDto branch in MapSchoolBranch)
                        {

                            if (branch.ClientBusinessClassification != null && branch.ClientBusinessClassification != 0)
                            {
                                var ClientBusinessClassification = _clientBusinessClassificationRepository.Get((int)branch.ClientBusinessClassification);
                                branch.ClientBusinessClassificationName = ClientBusinessClassification.Name;
                            }
                            if (branch.SchoolPlaceOwnership != 0)
                            {
                                var SchoolPlaceOwnership = _ownershipStatusRepository.Get(branch.SchoolPlaceOwnership);
                                branch.OwnershipStatusName = SchoolPlaceOwnership.Name;
                            }
                            if (branch.RentAgreementSignatory != null && branch.RentAgreementSignatory != 0)
                            {
                                var RentAgreementSignatory = _rentAgreementSignatoryRepository.Get((int)branch.RentAgreementSignatory);
                                branch.RentAgreementSignatoryName = RentAgreementSignatory.Name;
                            }
                            if (branch.SchoolBranchBusinessNature != null && branch.SchoolBranchBusinessNature != 0)
                            {
                                var SchoolBranchBusinessNature = _businessNatureRepository.Get((int)branch.SchoolBranchBusinessNature);
                                branch.SchoolBranchBusinessNatureName = SchoolBranchBusinessNature.Name;
                            }

                            if (branch.AcademicSession != null && branch.AcademicSession != 0)
                            {
                                var AcademicSession = _academicSessionRepository.Get((int)branch.AcademicSession);
                                branch.AcademicSessionName = AcademicSession.Name;
                            }

                            if (branch.Category != null && branch.Category != 0)
                            {
                                var Category = _schoolCategoryRepository.Get((int)branch.Category);
                                branch.CategoryName = Category.Name;
                            }

                            if (branch.BusinessType != null && branch.BusinessType != 0)
                            {
                                var BusinessType = _businessTypeRepository.Get((int)branch.BusinessType);
                                branch.BusinessTypeName = BusinessType.Name;
                            }
                            if (branch.SchoolLevel != null && branch.SchoolLevel != 0)
                            {
                                var SchoolLevel = _schoolLevelRepository.Get((int)branch.SchoolLevel);
                                branch.SchoolLevelName = SchoolLevel.Name;
                            }
                            if (branch.LegalStatus != null && branch.LegalStatus != 0)
                            {
                                var LegalStatus = _legalStatusRepository.Get((int)branch.LegalStatus);
                                branch.LegalStatusName = LegalStatus.Name;
                            }


                            //DateTime SubmittedDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Submitted);

                            //if (SubmittedDate != new DateTime())
                            //{
                            if (branch.EstablishedSince != null)
                            {
                                branch.CalculatedBusinessAge = getDuration(Convert.ToDateTime(branch.EstablishedSince), DateTime.Now);
                            }
                            if (branch.CurrentAddressSince != null)
                            {
                                branch.CalculatedTimeAtCurrentAddress = getDuration(Convert.ToDateTime(branch.CurrentAddressSince), DateTime.Now);
                            }

                            //}
                            //else
                            //{
                            //    branch.CalculatedBusinessAge = "--";
                            //    branch.CalculatedTimeAtCurrentAddress = "--";
                            //}

                            var deviation = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(ApplicationId);
                            if (deviation != null)
                            {
                                branch.AllowedMinBusinessAge = deviation.BusinessAgeYears;
                                branch.AllowedMinTimeAtCurrentAddress = deviation.BusinessAgeAtCurrentPlaceYears;
                            }







                            schoolsList.Add(branch);
                        }
                    }


                    result.school_Branches = schoolsList;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", businessDetailss));
            }
        }

        public bool CheckBusinessDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var getbusinessdetail = _businessDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (getbusinessdetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", businessDetailss));
            }
        }

        public string getDuration(DateTime dStart, DateTime dEnd)
        {
            DateTime startDate = dStart;
            DateTime endDate = dEnd;
            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;


            return string.Format("{0} years, {1} months, {2} days", years, months, days);
        }
    }
}
