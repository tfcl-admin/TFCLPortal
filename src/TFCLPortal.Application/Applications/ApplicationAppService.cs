using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlows;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.DescripentScreens;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.Mobilizations;
using TFCLPortal.MobilizationsLogs;
using TFCLPortal.Mobilizations.Dto;
using TFCLPortal.MobilizationsLogs.Dto;
using TFCLPortal.TaleemSchoolAsasahs;
using TFCLPortal.TaleemSchoolAsasahs.Dto;
using TFCLPortal.TaleemSchoolSarmayas;
using TFCLPortal.TaleemSchoolSarmayas.Dto;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.ApiCallLogs.Dto;
using Newtonsoft.Json;
using TFCLPortal.DeviationMatrices;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.ApplicationWorkFlows.BccStates;
using TFCLPortal.TaleemDostSahulats.Dto;
using TFCLPortal.TaleemDostSahulats;
using TFCLPortal.TaleemJariSahulats.Dto;
using TFCLPortal.TaleemJariSahulats;
using TFCLPortal.TaleemTeacherSahulats;
using TFCLPortal.TaleemTeacherSahulats.Dto;
using TFCLPortal.NotificationLogs;
using TFCLPortal.Branches;
using TFCLPortal.EnhancementRequests;
using TFCLPortal.Schedules;
using TFCLPortal.TaggedPortfolios;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.CustomerAccounts.Dto;
//using TFCLPortal.Schedules;

namespace TFCLPortal.Applications
{
    public class ApplicationAppService : TFCLPortalAppServiceBase, IApplicationAppService
    {
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IRepository<MobilizationStatus> _mobilizationStatusRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IMobilizationAppService _mobilizationAppService;
        private readonly IUserAppService _userAppService;
        private readonly IWorkFlowAppService _workFlowAppService;
        private readonly IWorkFlowApplicationStateAppService _flowApplicationStateAppService;
        private readonly IDescripentScreenAppService _descripentScreenAppService;
        private readonly IRepository<GuarantorDetail> _guarantorDetailAppService;
        private readonly IRepository<CoApplicantDetail> _CoApplicantDetailsrepo;
        private readonly ITaleemSchoolAsasahAppService _taleemSchoolAsasahAppService;
        private readonly ITaleemSchoolSarmayaAppService _taleemSchoolSarmayaAppService;
        private readonly ITaleemDostSahulatAppService _taleemDostSahulatAppService;
        private readonly ITaleemJariSahulatAppService _taleemJariSahulatAppService;
        private readonly ITaleemTeacherSahulatAppService _taleemTeacherSahulatAppService;
        private readonly IRepository<Mobilization, Int32> _mobilizationRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<MobilizationsLog, Int32> _mobilizationLogRepository;
        private readonly ICustomRepository _customRepository;
        private readonly IDeviationMatrixAppService _deviationMatrixAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly ITaggedPortfolioAppService _taggedPortfolioAppService;
        private readonly IBranchManagerActionAppService _branchManagerActionAppService;
        private string application = "Application";
        private readonly IBccStateAppService _bccStateAppService;
        //private readonly IScheduleAppService _scheduleAppService;
        private readonly INotificationLogAppService _notificationLogAppService;
        //private readonly IScheduleAppService _scheduleAppService;
        private readonly IRepository<CustomerAccount> _customerAccountRepository;
        private readonly IRepository<Branch> _branchRepository;
        private readonly IRepository<EnhancementRequest> _enhancementRequestRepository;



        public ApplicationAppService(IRepository<Applicationz> applicationRepository,
            IRepository<MobilizationStatus> mobilizationStatusRepository,
            IRepository<ProductType> ProductTyperepo,
            IMobilizationAppService mobilizationAppService,
            IUserAppService userAppService,
            IRepository<CustomerAccount> customerAccountRepository,
            //IScheduleAppService scheduleAppService,
            ITaggedPortfolioAppService taggedPortfolioAppService,
            IRepository<Branch> branchRepository,
            ITaleemJariSahulatAppService taleemJariSahulatAppService,
            ITaleemTeacherSahulatAppService taleemTeacherSahulatAppService,
            IWorkFlowAppService workFlowAppService,
            IWorkFlowApplicationStateAppService flowApplicationStateAppService,
            IDescripentScreenAppService descripentScreenAppService,
            //IScheduleAppService scheduleAppService,
            IFinalWorkflowAppService finalWorkflowAppService,
             IRepository<GuarantorDetail> guarantorDetailAppService,
               IRepository<CoApplicantDetail> CoApplicantDetailsrepo,
               INotificationLogAppService notificationLogAppService,
               IApiCallLogAppService apiCallLogAppService,
               IRepository<EnhancementRequest> enhancementRequestRepository,
            ITaleemSchoolAsasahAppService taleemSchoolAsasahAppService,
            ITaleemSchoolSarmayaAppService taleemSchoolSarmayaAppService,
            ICustomRepository customRepository,
            IBranchManagerActionAppService branchManagerActionAppService,
            ITaleemDostSahulatAppService taleemDostSahulatAppService,
            IDeviationMatrixAppService deviationMatrixAppService,
            IBccStateAppService bccStateAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IRepository<Mobilization, Int32> mobilizationRepository)
        {
            _notificationLogAppService = notificationLogAppService;
            _applicationRepository = applicationRepository;
            _customerAccountRepository = customerAccountRepository;
            //_scheduleAppService = scheduleAppService;
            //_scheduleAppService = scheduleAppService;
            _enhancementRequestRepository = enhancementRequestRepository;
            _branchRepository = branchRepository;
            _mobilizationStatusRepository = mobilizationStatusRepository;
            _productTypeRepository = ProductTyperepo;
            _mobilizationAppService = mobilizationAppService;
            _userAppService = userAppService;
            _workFlowAppService = workFlowAppService;
            _flowApplicationStateAppService = flowApplicationStateAppService;
            _descripentScreenAppService = descripentScreenAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _taleemSchoolAsasahAppService = taleemSchoolAsasahAppService;
            _taleemSchoolSarmayaAppService = taleemSchoolSarmayaAppService;
            _CoApplicantDetailsrepo = CoApplicantDetailsrepo;
            _taleemJariSahulatAppService = taleemJariSahulatAppService;
            _taleemTeacherSahulatAppService = taleemTeacherSahulatAppService;
            _customRepository = customRepository;
            _taggedPortfolioAppService = taggedPortfolioAppService;
            _mobilizationRepository = mobilizationRepository;
            _branchManagerActionAppService = branchManagerActionAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _deviationMatrixAppService = deviationMatrixAppService;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
            _bccStateAppService = bccStateAppService;
            _taleemDostSahulatAppService = taleemDostSahulatAppService;
        }

        public async Task<CnicCheckResponse> CheckCNIC(string cnic)
        {
            CnicCheckResponse response = new CnicCheckResponse();

            var cnicList = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == cnic.Trim() && x.ScreenStatus != "decline").ToList();

            if (cnicList.Count > 0)
            {
                var latestApplication = cnicList.Where(x => x.Id == cnicList.Max(y => y.Id)).FirstOrDefault();
                response.previousApplicationId = latestApplication.Id;
                response.previousProductType = latestApplication.ProductType;

                if (latestApplication.ScreenStatus == ApplicationState.Disbursed)
                {
                    response.status = 2;//Application Exists in Disbursed Status
                    response.MessageToShow = "CNIC already associated with Client ID : " + latestApplication.ClientID + ". Application is Currently Disbursed.";
                }
                else if (latestApplication.ScreenStatus == ApplicationState.Settled || latestApplication.ScreenStatus == ApplicationState.EarlySettled)
                {
                    response.status = 3;//Application Exists in Settled Or Early Settled
                    response.MessageToShow = "CNIC already associated with Client ID : " + latestApplication.ClientID + ". Application is Settled.";
                }
                else
                {
                    response.status = 4;//Application Exist. But not yet Disbursed
                    response.MessageToShow = "CNIC already associated with Client ID : " + latestApplication.ClientID + ". Application is currently in " + latestApplication.ScreenStatus + " state.";
                }
            }
            else
            {
                response.status = 1;//applications does not exist. New Customer
                response.previousApplicationId = -1;
                response.previousProductType = -1;
                response.MessageToShow = "";
            }

            return response;
        }

        public async Task<ApplicationResponse> CreateApplication(CreateApplicationDto input)
        {
            CreateApiCallLogDto callLog = new CreateApiCallLogDto();
            callLog.FunctionName = "CreateApplication";
            callLog.Input = JsonConvert.SerializeObject(input);
            var returnStr = _apiCallLogAppService.CreateApplication(callLog);

            ApplicationResponse Response = new ApplicationResponse();
            ApplicationResponse applicationResponse = new ApplicationResponse();

            if (input.MobilizationStatus == 4)
            {

                //var cnicList = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == input.CNICNo.Trim() && x.ScreenStatus != ApplicationState.Decline && x.ScreenStatus != "decline" && x.ScreenStatus != ApplicationState.Closed && x.ScreenStatus != ApplicationState.EarlySettled).FirstOrDefault();

                GuarantorDetail guarantor = null;

                guarantor = _guarantorDetailAppService.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == input.CNICNo.Trim()).FirstOrDefault();

                CoApplicantDetail coApplicant = null;
                if (guarantor == null)
                {
                    coApplicant = _CoApplicantDetailsrepo.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == input.CNICNo.Trim()).FirstOrDefault();

                }
                try
                {

                    //if (cnicList != null)
                    //{


                    //    Response.ApplicationId = 0;
                    //    Response.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                    //    Response.Message = "This CNIC (" + cnicList.CNICNo + ") has already been associated with Application No. " + cnicList.Id;
                    //    throw new UserFriendlyException(Response.Message);
                    //}
                    if (guarantor != null)
                    {
                        var cnic = _applicationRepository.GetAllList().Where(x => x.Id == guarantor.ApplicationId).FirstOrDefault();
                        if (cnic != null)
                        {

                            Response.ApplicationId = 0;
                            Response.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                            applicationResponse.Message = "This CNIC (" + guarantor.CNICNumber + ") is Gurantor in the Application (" + guarantor.ApplicationId + ") against the Applicant Cnic (" + cnic.CNICNo + ")";
                            throw new UserFriendlyException(Response.Message);
                        }

                    }
                    else if (coApplicant != null)
                    {
                        var cnic = _applicationRepository.GetAllList().Where(x => x.Id == coApplicant.ApplicationId).FirstOrDefault();
                        if (cnic != null)
                        {

                            Response.ApplicationId = 0;
                            Response.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                            Response.Message = "This CNIC (" + coApplicant.CNICNumber + ") is Co-Applicant in the Application (" + coApplicant.ApplicationId + ") against the Applicant Cnic (" + cnic.CNICNo + ")";
                            throw new UserFriendlyException(Response.Message);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException(Response.Message);
                }

            }

            try
            {
                if (input.MobilizationStatus == 4)
                {
                    var mobilizations = ObjectMapper.Map<Applicationz>(input);
                    mobilizations.ScreenStatus = ApplicationState.Created;

                    var currentUser = await _userAppService.GetUserById(input.CreatorUserId);
                    mobilizations.FK_branchid = currentUser.BranchId;

                    var applications = _applicationRepository.Insert(mobilizations);
                    CurrentUnitOfWork.SaveChanges();

                    var accounts = _customerAccountRepository.GetAllList(x=>x.CNIC==mobilizations.CNICNo).FirstOrDefault();
                    if(accounts!=null)
                    {
                        CustomerAccount account = new CustomerAccount();
                        account.CNIC = mobilizations.CNICNo;
                        account.Phone = mobilizations.MobileNo;
                        account.Name = mobilizations.ClientName;
                        account.Balance = 0;
                        account.isActive = true;
                        var accountCreation = _customerAccountRepository.Insert(account);
                    }

                    int ApplicationNumber = 0;

                    string clientID = "";

                    if (input.ProductType == 6 || input.ProductType == 2)
                    {
                        CreateTaleemSchoolAsasahDto asasahDto = new CreateTaleemSchoolAsasahDto();
                        asasahDto.ApplicationId = applications.Id;
                        ApplicationNumber = _taleemSchoolAsasahAppService.CreateTaleemSchoolAsasahAndReturnApplicationNumber(asasahDto);
                        clientID = "TSA-" + CreateClientIDbyAppNo(ApplicationNumber);
                    }
                    else if (input.ProductType == 7 || input.ProductType == 1)
                    {
                        CreateTaleemSchoolSarmayaDto sarmayaDto = new CreateTaleemSchoolSarmayaDto();
                        sarmayaDto.ApplicationId = applications.Id;
                        ApplicationNumber = _taleemSchoolSarmayaAppService.CreateTaleemSchoolSarmayaAndReturnApplicationNumber(sarmayaDto);
                        clientID = "TSS-" + CreateClientIDbyAppNo(ApplicationNumber);
                    }
                    else if (input.ProductType == 8)
                    {
                        CreateTaleemDostSahulatDto dostDto = new CreateTaleemDostSahulatDto();
                        dostDto.ApplicationId = applications.Id;
                        ApplicationNumber = _taleemDostSahulatAppService.CreateTaleemDostSahulatAndReturnApplicationNumber(dostDto);
                        clientID = "TDS-" + CreateClientIDbyAppNo(ApplicationNumber);
                    }
                    else if (input.ProductType == 9)
                    {
                        CreateTaleemJariSahulatDto jariDto = new CreateTaleemJariSahulatDto();
                        jariDto.ApplicationId = applications.Id;
                        ApplicationNumber = _taleemJariSahulatAppService.CreateTaleemJariSahulatAndReturnApplicationNumber(jariDto);
                        clientID = "TJS-" + CreateClientIDbyAppNo(ApplicationNumber);
                    }
                    else if (input.ProductType == 10)
                    {
                        CreateTaleemTeacherSahulatDto TeacherDto = new CreateTaleemTeacherSahulatDto();
                        TeacherDto.ApplicationId = applications.Id;
                        ApplicationNumber = _taleemTeacherSahulatAppService.CreateTaleemTeacherSahulatAndReturnApplicationNumber(TeacherDto);
                        clientID = "TTS-" + CreateClientIDbyAppNo(ApplicationNumber);
                    }

                    var applicationSaveAppNumber = _applicationRepository.GetAllList().Where(x => x.Id == applications.Id).Single();
                    applicationSaveAppNumber.ApplicationNumber = ApplicationNumber;
                    applicationSaveAppNumber.ClientID = clientID;
                    _applicationRepository.Update(applicationSaveAppNumber);


                    //Getting Current Deviation Matrix Values
                    var DeviationMatrixObj = _deviationMatrixAppService.GetDeviationMatrixByProductId(input.ProductType);

                    //Assignment of Deviation Matrix Values to ApplicationWise Model
                    CreateApplicationWiseDeviationVariableDto obj = new CreateApplicationWiseDeviationVariableDto();
                    obj.ApplicationId = applications.Id;
                    obj.fk_ProductId = DeviationMatrixObj.Result.fk_ProductId;
                    obj.MinLimitForUnsecuredLoan = DeviationMatrixObj.Result.MinLimitForUnsecuredLoan;
                    obj.MaxLimitForUnsecuredLoan = DeviationMatrixObj.Result.MaxLimitForUnsecuredLoan;
                    obj.ApplicantMinAge = DeviationMatrixObj.Result.ApplicantMinAge;
                    obj.ApplicantMaxAge = DeviationMatrixObj.Result.ApplicantMaxAge;
                    obj.BusinessAgeYears = DeviationMatrixObj.Result.BusinessAgeYears;
                    obj.BusinessAgeAtCurrentPlaceYears = DeviationMatrixObj.Result.BusinessAgeAtCurrentPlaceYears;
                    obj.MinPercentageOfSAexpAgainstSAincome = DeviationMatrixObj.Result.MinPercentageOfSAexpAgainstSAincome;
                    obj.MaxPercentageOfNAItotalSchoolRevenue = DeviationMatrixObj.Result.MaxPercentageOfNAItotalSchoolRevenue;
                    obj.MinPercentageOfHHEtotalSchoolRevenue = DeviationMatrixObj.Result.MinPercentageOfHHEtotalSchoolRevenue;
                    obj.MaxLimitForInstallmentRatio = DeviationMatrixObj.Result.MaxLimitForInstallmentRatio;
                    obj.GuarantorMinAge = DeviationMatrixObj.Result.GuarantorMinAge;
                    obj.GuarantorMaxAge = DeviationMatrixObj.Result.GuarantorMaxAge;

                    obj.LTVForResidentialBuilding = DeviationMatrixObj.Result.LTVForResidentialBuilding;
                    obj.LTVForResidentialLand = DeviationMatrixObj.Result.LTVForResidentialLand;
                    obj.LTVForCommercialBuilding = DeviationMatrixObj.Result.LTVForCommercialBuilding;
                    obj.LTVForCommercialLand = DeviationMatrixObj.Result.LTVForCommercialLand;
                    obj.LTVForAgriculturalLand = DeviationMatrixObj.Result.LTVForAgriculturalLand;
                    obj.LTVForVehicleLessThanOneYear = DeviationMatrixObj.Result.LTVForVehicleLessThanOneYear;
                    obj.LTVForVehicleLessThanFiveYear = DeviationMatrixObj.Result.LTVForVehicleLessThanFiveYear;
                    obj.LTVForVehicleMoreThanFiveYear = DeviationMatrixObj.Result.LTVForVehicleMoreThanFiveYear;
                    obj.LTVForTDRratedA = DeviationMatrixObj.Result.LTVForTDRratedA;
                    obj.LTVForTDRratedB = DeviationMatrixObj.Result.LTVForTDRratedB;
                    obj.LTVForFranchiseAgreement = DeviationMatrixObj.Result.LTVForFranchiseAgreement;
                    obj.LTVForGold = DeviationMatrixObj.Result.LTVForGold;
                    obj.MinStudentEnrolled = DeviationMatrixObj.Result.MinStudentEnrolled;

                    //Saving of Deviation Matrix Values to ApplicationWise Model
                    await _applicationWiseDeviationVariableAppService.CreateApplicationWiseDeviationVariable(obj);

                    if (applications.Id > 0)
                    {
                        var workFlow = UserInRole(WorkFlowState.BA_DataCheck);

                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = applications.Id;
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = "Current";

                        await ChangeWorkFlowState(createWorkFlow);
                    }

                    if (applications.Id > 0)
                    {
                        var workFlow = UserInRole(WorkFlowState.BA_DataCheck);

                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = applications.Id;
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = "Current";

                        await ChangeWorkFlowState(createWorkFlow);

                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = applications.Id;
                        fWobj.Action = "Customer Acquired";
                        fWobj.ActionBy = (int)applications.CreatorUserId;
                        fWobj.ApplicationState = "Created";
                        fWobj.isActive = true;

                        await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                        //Sending Notifications to BA
                        await _notificationLogAppService.SendNotification(63, clientID, "Customer has been Acquired.");
                    }


                    applicationResponse.ApplicationId = applications.Id;
                    applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                    applicationResponse.ClientId = clientID;

                    //Returning of Deviation Matrix per this application
                    applicationResponse.ApplicationId = obj.ApplicationId;
                    applicationResponse.fk_ProductId = obj.fk_ProductId;
                    applicationResponse.MinLimitForUnsecuredLoan = obj.MinLimitForUnsecuredLoan;
                    applicationResponse.MaxLimitForUnsecuredLoan = obj.MaxLimitForUnsecuredLoan;
                    applicationResponse.ApplicantMinAge = obj.ApplicantMinAge;
                    applicationResponse.ApplicantMaxAge = obj.ApplicantMaxAge;
                    applicationResponse.BusinessAgeYears = obj.BusinessAgeYears;
                    applicationResponse.BusinessAgeAtCurrentPlaceYears = obj.BusinessAgeAtCurrentPlaceYears;
                    applicationResponse.MinPercentageOfSAexpAgainstSAincome = obj.MinPercentageOfSAexpAgainstSAincome;
                    applicationResponse.MaxPercentageOfNAItotalSchoolRevenue = obj.MaxPercentageOfNAItotalSchoolRevenue;
                    applicationResponse.MinPercentageOfHHEtotalSchoolRevenue = obj.MinPercentageOfHHEtotalSchoolRevenue;
                    applicationResponse.MaxLimitForInstallmentRatio = obj.MaxLimitForInstallmentRatio;
                    applicationResponse.GuarantorMinAge = obj.GuarantorMinAge;
                    applicationResponse.GuarantorMaxAge = obj.GuarantorMaxAge;

                    applicationResponse.LTVForResidentialBuilding = obj.LTVForResidentialBuilding;
                    applicationResponse.LTVForResidentialLand = obj.LTVForResidentialLand;
                    applicationResponse.LTVForCommercialBuilding = obj.LTVForCommercialBuilding;
                    applicationResponse.LTVForCommercialLand = obj.LTVForCommercialLand;
                    applicationResponse.LTVForAgriculturalLand = obj.LTVForAgriculturalLand;
                    applicationResponse.LTVForVehicleLessThanOneYear = obj.LTVForVehicleLessThanOneYear;
                    applicationResponse.LTVForVehicleLessThanFiveYear = obj.LTVForVehicleLessThanFiveYear;
                    applicationResponse.LTVForVehicleMoreThanFiveYear = obj.LTVForVehicleMoreThanFiveYear;
                    applicationResponse.LTVForTDRratedA = obj.LTVForTDRratedA;
                    applicationResponse.LTVForTDRratedB = obj.LTVForTDRratedB;
                    applicationResponse.LTVForFranchiseAgreement = obj.LTVForFranchiseAgreement;
                    applicationResponse.LTVForGold = obj.LTVForGold;
                    applicationResponse.MinStudentEnrolled = obj.MinStudentEnrolled;

                    return applicationResponse;
                }
                else
                {
                    if (input.ProductType != 0)
                    {

                        CreateMobilizationDto createMobilization = new CreateMobilizationDto();
                        createMobilization.ClientName = input.ClientName;
                        createMobilization.MobileNo = input.MobileNo;
                        createMobilization.LandLineNo = input.LandLineNo;
                        createMobilization.CNICNo = input.CNICNo;
                        createMobilization.Address = input.Address;
                        createMobilization.SchoolName = input.SchoolName;
                        createMobilization.MobilizationStatus = input.MobilizationStatus;
                        createMobilization.ProductType = input.ProductType;
                        createMobilization.NextMeeting = input.NextMeeting;
                        createMobilization.ScreenStatus = input.ScreenStatus;
                        createMobilization.Comments = input.Comments;
                        createMobilization.BranchCode = input.BranchCode;
                        createMobilization.CreatorUserId = input.CreatorUserId;

                        //added new field to dto
                        createMobilization.Remarks = input.Remarks;
                        createMobilization.AverageFee = input.AverageFee;
                        createMobilization.PrefixLable = input.PrefixLable;
                        createMobilization.RespondantDesignation = input.RespondantDesignation;
                        createMobilization.ApplicantSource = input.ApplicationSource;
                        createMobilization.PersonNotInterested = input.PersonNotInterested;
                        createMobilization.PrefferedProduct = input.PrefferedProduct;
                        createMobilization.MentionProviderInterest = input.MentionProviderInterest;
                        createMobilization.DecesionMonth = input.DecesionMonth;
                        createMobilization.NoOfStudent = input.NoOfStudent;
                        createMobilization.NoOfStaff = input.NoOfStaff;
                        createMobilization.BuildingStatus = input.BuildingStatus;
                        createMobilization.AreaOfSchoolMarla = input.AreaOfSchoolMarla;
                        createMobilization.AcademicSession = input.AcademicSession;

                        //added new fields by saad
                        createMobilization.OtherSourceIncome = input.OtherSourceIncome;
                        createMobilization.OtherSourceIncomeOthers = input.OtherSourceIncomeOthers;
                        createMobilization.AnyOtherBusiness = input.AnyOtherBusiness;
                        createMobilization.isAvailedLoan = input.isAvailedLoan;
                        createMobilization.SchoolCategory = input.SchoolCategory;
                        createMobilization.Longitude = input.Longitude;
                        createMobilization.Latitude = input.Latitude;
                        createMobilization.InteractionNumber = input.InteractionNumber;
                        createMobilization.MobilizationTableID = input.MobilizationTableID;
                        createMobilization.otherApplicantSource = input.otherApplicantSource;
                        createMobilization.otherNotbeingIntersted = input.otherNotbeingIntersted;
                        createMobilization.otherSchoolBuildingStatus = input.otherSchoolBuildingStatus;
                        createMobilization.TDSBusinessNature = input.TDSBusinessNature;
                        createMobilization.UpdateRecordId = input.UpdateRecordId;

                        //Update In Mobilizations Due to TDS,TJS,TTS.
                        createMobilization.ContactSource = input.ContactSource;
                        createMobilization.ApplicantType = input.ApplicantType;
                        createMobilization.FiName = input.FiName;
                        createMobilization.Designation = input.Designation;
                        createMobilization.MonthlySalary = input.MonthlySalary;
                        createMobilization.JobTenure = input.JobTenure;
                        createMobilization.SchoolGoingDependants = input.SchoolGoingDependants;
                        createMobilization.MobilizationRecordId = input.MobilizationRecordId;


                        //end fields by saad

                        return await _mobilizationAppService.CreateMobilization(createMobilization);

                    }
                    else
                    {
                        throw new UserFriendlyException(L("CreateMethodError{0}", application));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", application));
            }
        }

        public async Task<ApplicationResponse> MigrateEnhancementApplication(int OldApplicationId)
        {
            CreateApiCallLogDto callLog = new CreateApiCallLogDto();
            callLog.FunctionName = "MigrateEnhancementApplication";
            callLog.Input = JsonConvert.SerializeObject("ApplicationID : " + OldApplicationId);
            var returnStr = _apiCallLogAppService.CreateApplication(callLog);

            ApplicationResponse Response = new ApplicationResponse();
            ApplicationResponse applicationResponse = new ApplicationResponse();
            try
            {
                var enhancement = _enhancementRequestRepository.GetAllList(x => x.ApplicationId == OldApplicationId).FirstOrDefault();

                if (enhancement.RequestState == 1)//isApproved
                {


                    var OldApp = _applicationRepository.Get(OldApplicationId);

                    Applicationz NewApplication = new Applicationz();

                    NewApplication.ApplicationId = OldApp.ApplicationId;
                    NewApplication.ClientID = OldApp.ClientID;
                    NewApplication.ClientName = OldApp.ClientName;
                    NewApplication.MobileNo = OldApp.MobileNo;
                    NewApplication.LandLineNo = OldApp.LandLineNo;
                    NewApplication.CNICNo = OldApp.CNICNo;
                    NewApplication.Address = OldApp.Address;
                    NewApplication.SchoolName = OldApp.SchoolName;
                    NewApplication.MobilizationStatus = OldApp.MobilizationStatus;
                    NewApplication.ProductType = OldApp.ProductType;
                    NewApplication.NextMeeting = OldApp.NextMeeting;
                    NewApplication.ScreenStatus = ApplicationState.InProcess;
                    NewApplication.Comments = OldApp.Comments;
                    NewApplication.BranchCode = OldApp.BranchCode;
                    NewApplication.CreatorUserId = OldApp.CreatorUserId;
                    NewApplication.FK_branchid = OldApp.FK_branchid;
                    NewApplication.Remarks = OldApp.Remarks;
                    NewApplication.AverageFee = OldApp.AverageFee;
                    NewApplication.PrefixLable = OldApp.PrefixLable;
                    NewApplication.RespondantDesignation = OldApp.RespondantDesignation;
                    NewApplication.PersonNotInterested = OldApp.PersonNotInterested;
                    NewApplication.MentionProviderInterest = OldApp.MentionProviderInterest;
                    NewApplication.DecesionMonth = OldApp.DecesionMonth;
                    NewApplication.NoOfStudent = OldApp.NoOfStudent;
                    NewApplication.NoOfStaff = OldApp.NoOfStaff;
                    NewApplication.BuildingStatus = OldApp.BuildingStatus;
                    NewApplication.AreaOfSchoolMarla = OldApp.AreaOfSchoolMarla;
                    NewApplication.AcademicSession = OldApp.AcademicSession;
                    NewApplication.FranchiserName = OldApp.FranchiserName;
                    NewApplication.isFranchise = OldApp.isFranchise;
                    NewApplication.Longitude = OldApp.Longitude;
                    NewApplication.Latitude = OldApp.Latitude;
                    NewApplication.SchoolCategory = OldApp.SchoolCategory;
                    NewApplication.ApplicantType = OldApp.ApplicantType;


                    NewApplication.PrevApplicationId = OldApplicationId;
                    NewApplication.isEnhancementApplication = true;

                    var NewApplicationId = _applicationRepository.InsertAndGetId(NewApplication);

                    enhancement.RequestState = 3;
                    _enhancementRequestRepository.Update(enhancement);

                    if (NewApplicationId != 0)
                    {
                        //Getting Current Deviation Matrix Values
                        var DeviationMatrixObj = _deviationMatrixAppService.GetDeviationMatrixByProductId(NewApplication.ProductType);

                        //Assignment of Deviation Matrix Values to ApplicationWise Model
                        CreateApplicationWiseDeviationVariableDto obj = new CreateApplicationWiseDeviationVariableDto();
                        obj.ApplicationId = NewApplicationId;
                        obj.fk_ProductId = DeviationMatrixObj.Result.fk_ProductId;
                        obj.MinLimitForUnsecuredLoan = DeviationMatrixObj.Result.MinLimitForUnsecuredLoan;
                        obj.MaxLimitForUnsecuredLoan = DeviationMatrixObj.Result.MaxLimitForUnsecuredLoan;
                        obj.ApplicantMinAge = DeviationMatrixObj.Result.ApplicantMinAge;
                        obj.ApplicantMaxAge = DeviationMatrixObj.Result.ApplicantMaxAge;
                        obj.BusinessAgeYears = DeviationMatrixObj.Result.BusinessAgeYears;
                        obj.BusinessAgeAtCurrentPlaceYears = DeviationMatrixObj.Result.BusinessAgeAtCurrentPlaceYears;
                        obj.MinPercentageOfSAexpAgainstSAincome = DeviationMatrixObj.Result.MinPercentageOfSAexpAgainstSAincome;
                        obj.MaxPercentageOfNAItotalSchoolRevenue = DeviationMatrixObj.Result.MaxPercentageOfNAItotalSchoolRevenue;
                        obj.MinPercentageOfHHEtotalSchoolRevenue = DeviationMatrixObj.Result.MinPercentageOfHHEtotalSchoolRevenue;
                        obj.MaxLimitForInstallmentRatio = DeviationMatrixObj.Result.MaxLimitForInstallmentRatio;
                        obj.GuarantorMinAge = DeviationMatrixObj.Result.GuarantorMinAge;
                        obj.GuarantorMaxAge = DeviationMatrixObj.Result.GuarantorMaxAge;

                        obj.LTVForResidentialBuilding = DeviationMatrixObj.Result.LTVForResidentialBuilding;
                        obj.LTVForResidentialLand = DeviationMatrixObj.Result.LTVForResidentialLand;
                        obj.LTVForCommercialBuilding = DeviationMatrixObj.Result.LTVForCommercialBuilding;
                        obj.LTVForCommercialLand = DeviationMatrixObj.Result.LTVForCommercialLand;
                        obj.LTVForAgriculturalLand = DeviationMatrixObj.Result.LTVForAgriculturalLand;
                        obj.LTVForVehicleLessThanOneYear = DeviationMatrixObj.Result.LTVForVehicleLessThanOneYear;
                        obj.LTVForVehicleLessThanFiveYear = DeviationMatrixObj.Result.LTVForVehicleLessThanFiveYear;
                        obj.LTVForVehicleMoreThanFiveYear = DeviationMatrixObj.Result.LTVForVehicleMoreThanFiveYear;
                        obj.LTVForTDRratedA = DeviationMatrixObj.Result.LTVForTDRratedA;
                        obj.LTVForTDRratedB = DeviationMatrixObj.Result.LTVForTDRratedB;
                        obj.LTVForFranchiseAgreement = DeviationMatrixObj.Result.LTVForFranchiseAgreement;
                        obj.LTVForGold = DeviationMatrixObj.Result.LTVForGold;
                        obj.MinStudentEnrolled = DeviationMatrixObj.Result.MinStudentEnrolled;

                        //Saving of Deviation Matrix Values to ApplicationWise Model
                        await _applicationWiseDeviationVariableAppService.CreateApplicationWiseDeviationVariable(obj);



                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = NewApplicationId;
                        fWobj.Action = "Customer Enhancement Approved";
                        fWobj.ActionBy = (int)NewApplication.CreatorUserId;
                        fWobj.ApplicationState = "Created";
                        fWobj.isActive = true;

                        await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                        //Sending Notifications to BA
                        await _notificationLogAppService.SendNotification(63, NewApplication.ClientID, "Customer has been Acquired.");

                        applicationResponse.ApplicationId = NewApplicationId;
                        applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                        applicationResponse.ClientId = NewApplication.ClientID;

                        //Returning of Deviation Matrix per this application
                        applicationResponse.ApplicationId = obj.ApplicationId;
                        applicationResponse.fk_ProductId = obj.fk_ProductId;
                        applicationResponse.MinLimitForUnsecuredLoan = obj.MinLimitForUnsecuredLoan;
                        applicationResponse.MaxLimitForUnsecuredLoan = obj.MaxLimitForUnsecuredLoan;
                        applicationResponse.ApplicantMinAge = obj.ApplicantMinAge;
                        applicationResponse.ApplicantMaxAge = obj.ApplicantMaxAge;
                        applicationResponse.BusinessAgeYears = obj.BusinessAgeYears;
                        applicationResponse.BusinessAgeAtCurrentPlaceYears = obj.BusinessAgeAtCurrentPlaceYears;
                        applicationResponse.MinPercentageOfSAexpAgainstSAincome = obj.MinPercentageOfSAexpAgainstSAincome;
                        applicationResponse.MaxPercentageOfNAItotalSchoolRevenue = obj.MaxPercentageOfNAItotalSchoolRevenue;
                        applicationResponse.MinPercentageOfHHEtotalSchoolRevenue = obj.MinPercentageOfHHEtotalSchoolRevenue;
                        applicationResponse.MaxLimitForInstallmentRatio = obj.MaxLimitForInstallmentRatio;
                        applicationResponse.GuarantorMinAge = obj.GuarantorMinAge;
                        applicationResponse.GuarantorMaxAge = obj.GuarantorMaxAge;

                        applicationResponse.LTVForResidentialBuilding = obj.LTVForResidentialBuilding;
                        applicationResponse.LTVForResidentialLand = obj.LTVForResidentialLand;
                        applicationResponse.LTVForCommercialBuilding = obj.LTVForCommercialBuilding;
                        applicationResponse.LTVForCommercialLand = obj.LTVForCommercialLand;
                        applicationResponse.LTVForAgriculturalLand = obj.LTVForAgriculturalLand;
                        applicationResponse.LTVForVehicleLessThanOneYear = obj.LTVForVehicleLessThanOneYear;
                        applicationResponse.LTVForVehicleLessThanFiveYear = obj.LTVForVehicleLessThanFiveYear;
                        applicationResponse.LTVForVehicleMoreThanFiveYear = obj.LTVForVehicleMoreThanFiveYear;
                        applicationResponse.LTVForTDRratedA = obj.LTVForTDRratedA;
                        applicationResponse.LTVForTDRratedB = obj.LTVForTDRratedB;
                        applicationResponse.LTVForFranchiseAgreement = obj.LTVForFranchiseAgreement;
                        applicationResponse.LTVForGold = obj.LTVForGold;
                        applicationResponse.MinStudentEnrolled = obj.MinStudentEnrolled;


                        applicationResponse.OldApplication = GetApplicationById(OldApplicationId);
                        //applicationResponse.NewApplication = GetApplicationById(NewApplicationId);


                        return applicationResponse;
                    }

                    else
                    {
                        throw new UserFriendlyException(L("CreateMethodError{0}", application));
                    }
                }
                else
                {
                    throw new UserFriendlyException(L("CreateMethodError{0}", application));
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", application));
            }
        }

        private string CreateClientIDbyAppNo(int applicationNumber)
        {
            if (applicationNumber < 10)
            {
                return "0000" + applicationNumber;
            }
            else if (applicationNumber < 100)
            {
                return "000" + applicationNumber;
            }
            else if (applicationNumber < 1000)
            {
                return "00" + applicationNumber;
            }
            else if (applicationNumber < 10000)
            {
                return "0" + applicationNumber;
            }
            else
            {
                return applicationNumber.ToString();
            }
        }

        public ApplicationListDto GetApplicationById(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var mobilizations = _applicationRepository.Get(Id);
                    if (mobilizations != null)
                    {
                        var obj = ObjectMapper.Map<ApplicationListDto>(mobilizations);
                        if (obj.ProductType != 0)
                        {
                            var product = _productTypeRepository.Get(obj.ProductType);
                            obj.ProductTypeName = product.Name;
                        }
                        if (obj.MobilizationStatus != 0)
                        {
                            var Mobilization = _mobilizationStatusRepository.Get(obj.MobilizationStatus);
                            obj.MobilizationStatusName = Mobilization.Name;
                        }
                        return obj;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public async Task<ApplicationListDto> GetApplicationByIdAsync(int Id)
        {
            try
            {
                var mobilizations = _applicationRepository.GetAsync(Id).Result;

                var obj = ObjectMapper.Map<ApplicationListDto>(mobilizations);

                if (obj != null)
                {
                    if (obj.ProductType != 0)
                    {
                        var product = _productTypeRepository.GetAsync(obj.ProductType).Result;
                        obj.ProductTypeName = product.Name;
                    }
                    if (obj.MobilizationStatus != 0)
                    {
                        var Mobilization = _mobilizationStatusRepository.GetAsync(obj.MobilizationStatus).Result;
                        obj.MobilizationStatusName = Mobilization.Name;
                    }
                }

                return obj;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public async Task<string> UpdateApplication(UpdateApplicationDto input)
        {
            string ResponseString = "";
            try
            {
                var mobilizations = _applicationRepository.Get(input.Id);
                if (mobilizations != null && mobilizations.Id > 0)
                {
                    ObjectMapper.Map(input, mobilizations);
                    await _applicationRepository.UpdateAsync(mobilizations);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", application));
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", application));
            }
        }


        public string UpdateApplicationLastScreen(string LastScreen, int ApplicationId)
        {
            string ResponseString = "";
            try
            {
                var application = _applicationRepository.Get(ApplicationId);
                if (application != null && application.Id > 0)
                {

                    //ObjectMapper.Map(uadto, application);
                    application.LastScreen = LastScreen;
                    if (application.ScreenStatus == ApplicationState.Created)
                    {
                        application.ScreenStatus = ApplicationState.InProcess;
                    }
                    _applicationRepository.Update(application);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    return ResponseString = "Application Id Not Found";
                }

            }
            catch (Exception ex)
            {
                return ResponseString = "Error";
                //throw new UserFriendlyException(L("UpdateMethodError{0}", application));
            }

        }
        public ApplicationListDto GetApplicationByApplicationId(int Id)
        {
            try
            {
                var mobilizations = _applicationRepository.GetAllList().Where(x => x.Id == Id).FirstOrDefault();

                var obj = ObjectMapper.Map<ApplicationListDto>(mobilizations);
                var initChat = (from mob in _applicationRepository.GetAllList()
                                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                                join mobilization in _mobilizationStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id

                                where mob.Id == Id
                                select new
                                {
                                    mob,
                                    producttype = product.Name,
                                    MobilizationStatus = mobilization.Name,

                                }).FirstOrDefault();

                if (initChat != null)
                {
                    obj.ProductTypeName = initChat.producttype;
                    obj.MobilizationStatusName = initChat.MobilizationStatus;

                }
                return obj;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<Applicationz> GetShortApplicationList(string applicationState, int? branchId)
        {
            try
            {
                if (branchId == null || branchId == 0)
                {
                    return _applicationRepository.GetAllList(x => x.ScreenStatus == applicationState).ToList();
                }
                else
                {
                    int branch = (int)branchId;
                    return _applicationRepository.GetAllList(x => x.ScreenStatus == applicationState && x.FK_branchid == branch).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<Applicationz> GetBCCShortApplicationList(int userid)
        {
            try
            {
                List<Applicationz> apps = new List<Applicationz>();
                //var getBCC = _bccStateAppService.GetBccStateListByUserId(userid).Result.ToList();
                var getBCC = _bccStateAppService.GetBccStateListByUserId(userid).Result.Where(x => x.Fk_UserId == userid && x.Status == "Active").ToList();

                if (getBCC != null)
                {
                    foreach (var bcc in getBCC)
                    {
                        var application = _applicationRepository.Get(bcc.ApplicationId);
                        apps.Add(application);
                    }

                }


                return apps;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<Applicationz> GetAllApplicationsByUserId(int userid)
        {
            try
            {

                var applications = _applicationRepository.GetAllList(x => x.CreatorUserId == userid).ToList();
                return applications;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<Applicationz> GetAllBCCReviewedApplicationsByUserId(int userid)
        {
            try
            {

                var applications = _applicationRepository.GetAllList(x => x.ScreenStatus == ApplicationState.BCCReviewed).ToList();
                List<Applicationz> returnList = new List<Applicationz>();
                foreach (var app in applications)
                {
                    var getBCC = _bccStateAppService.GetBccStateListByApplicationId(app.Id).Result.Where(x => x.Fk_UserId == userid).LastOrDefault();

                    if (getBCC != null)
                    {
                        var tobeAdded = applications.Where(x => x.Id == app.Id).LastOrDefault();
                        returnList.Add(tobeAdded);
                    }
                }

                return applications;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<ApplicationDto> GetApplicationList(string applicationState, int? branchId, bool showAll = false, bool IsAdmin = false, bool isEnhanced = false)
        {
            try
            {
                if (branchId == null)
                {
                    return _customRepository.GetAllApplicationList(applicationState, 0, showAll, IsAdmin, isEnhanced);
                }
                else
                {
                    return _customRepository.GetAllApplicationList(applicationState, (int)branchId, showAll, IsAdmin, isEnhanced);
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<ApplicationListDto> GetAllApplicationsList()
        {
            try
            {
                var apps = _applicationRepository.GetAllList();

                var appsList = ObjectMapper.Map<List<ApplicationListDto>>(apps);

                return appsList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }
        public List<ApplicationListCrsDto> GetAllApplicationsListForCRS()
        {
            try
            {
                var apps = _applicationRepository.GetAllList();

                var appsList = ObjectMapper.Map<List<ApplicationListCrsDto>>(apps);

                var products = _productTypeRepository.GetAllList();
                var branches = _branchRepository.GetAllList();


                foreach (var app in appsList)
                {
                    app.ProductTypeName = products.Where(x => x.Id == app.ProductType).FirstOrDefault().Name;
                    app.ProductTypeShortCode = products.Where(x => x.Id == app.ProductType).FirstOrDefault().ShortCode;
                    app.BranchCode = branches.Where(x => x.Id == app.FK_branchid).FirstOrDefault().BranchCode;
                }

                return appsList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<ApplicationListCrsDto> GetAllApplicationsListforcrsTSSTSA()
        {
            try
            {
                var apps = _applicationRepository.GetAllList(x => x.ProductType == 1 || x.ProductType == 2 || x.ProductType == 6 || x.ProductType == 7).ToList();

                var appsList = ObjectMapper.Map<List<ApplicationListCrsDto>>(apps);

                var products = _productTypeRepository.GetAllList();
                var branches = _branchRepository.GetAllList();


                foreach (var app in appsList)
                {
                    app.ProductTypeName = products.Where(x => x.Id == app.ProductType).FirstOrDefault().Name;
                    app.ProductTypeShortCode = products.Where(x => x.Id == app.ProductType).FirstOrDefault().ShortCode;
                    app.BranchCode = branches.Where(x => x.Id == app.FK_branchid).FirstOrDefault().BranchCode;
                }

                return appsList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public Task<DashboardDataDto> GetTFCLDashboardCountingData(int branchId)
        {
            try
            {
                return _customRepository.GetTFCLDashboardCountingData(branchId);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public Task<List<HighChartWeeklyDto>> GetHighChartWeekData()
        {
            try
            {
                return _customRepository.GetHighChartWeeklyData();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public Task<List<BranchPortfolioGraphDto>> GetBranchPortfolioGraphData()
        {
            try
            {
                return _customRepository.GetBranchPortfolioGraphData();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }


        public Task<List<MonthWiseGraphDto>> GetMonthlyGraphData()
        {
            try
            {
                return _customRepository.GetMonthlyGraphData();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public Task<List<ProductwiseDto>> GetProductWiseAmount()
        {
            try
            {
                return _customRepository.GetProductWiseAmount();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public string ChangeApplicationState(string state, int ApplicationId, string comments)
        {
            var ResponseString = "";
            try
            {
                var applicationObj = _applicationRepository.GetAllList(x => x.Id == ApplicationId).FirstOrDefault();

                applicationObj.ScreenStatus = state;
                applicationObj.Comments = comments;
                if (applicationObj != null && applicationObj.Id > 0)
                {
                    _applicationRepository.Update(applicationObj);
                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Application state has been Changed";
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
            return ResponseString;
        }

        public async Task<string> ChangeApplicationStateAsync(string state, int ApplicationId, string comments)
        {
            var ResponseString = "";
            try
            {
                var applicationObj = _applicationRepository.GetAllListAsync(x => x.Id == ApplicationId).Result.FirstOrDefault();

                applicationObj.ScreenStatus = state;
                applicationObj.Comments = comments;
                if (applicationObj != null && applicationObj.Id > 0)
                {
                    _applicationRepository.UpdateAsync(applicationObj);
                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Application state has been Changed";
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
            return ResponseString;
        }

        public async Task<WorkFlowReturnDto> UserInRole(string name)
        {

            var workFlow = _workFlowAppService.GetWorkFlowByName(name);
            int workFlowId = workFlow.Id;
            long UserId = 0;
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            foreach (var user in users)
            {
                if (user.RoleNames.Contains(name.ToUpper()))
                {
                    UserId = user.Id;
                    break;
                }
            }
            WorkFlowReturnDto returnDto = new WorkFlowReturnDto();
            returnDto.UserId = (int)UserId;
            returnDto.WorkFlowId = workFlowId;

            return returnDto;
        }

        public async Task ChangeWorkFlowState(CreateWorkFlowApplicationStateDto createWorkFlow)
        {
            var LastWorkFlow = _flowApplicationStateAppService.GetLastActiveWorkFlow(createWorkFlow.ApplicationId);
            if (LastWorkFlow != null)
            {


                UpdateWorkFlowApplicationStateDto update = new UpdateWorkFlowApplicationStateDto();
                update.Fk_WorkFlowId = LastWorkFlow.Fk_WorkFlowId;
                update.IsActive = false;
                update.Fk_UserId = LastWorkFlow.Fk_UserId;
                update.ApplicationId = LastWorkFlow.ApplicationId;
                update.Status = "Closed";
                update.Fk_BccId = LastWorkFlow.Fk_BccId;
                update.Id = LastWorkFlow.Id;

                await _flowApplicationStateAppService.UpdateWorkFlowApplicationState(update);
            }

            await _flowApplicationStateAppService.CreateWorkFlowApplicationState(createWorkFlow);

        }

        public List<ApplicationListDto> GetDeclineApplicationbyUserId(int UserId)
        {
            try
            {
                var applications = _applicationRepository.GetAllList(x => x.CreatorUserId == UserId && x.ScreenStatus.Contains("Decline")).ToList();

                var objmobilizationsList = ObjectMapper.Map<List<ApplicationListDto>>(applications);

                var initChat = (from mob in _applicationRepository.GetAllList()
                                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                                join mobilization in _mobilizationStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id
                                select new
                                {
                                    mob.Id,
                                    producttype = product.Name,
                                    MobilizationStatus = mobilization.Name,

                                }).ToList();

                List<ApplicationListDto> mobilizationListDtoList = new List<ApplicationListDto>();

                foreach (var objMob in objmobilizationsList)
                {
                    foreach (var objInitChat in initChat)
                    {
                        if (objMob.Id == objInitChat.Id)
                        {
                            objMob.ProductTypeName = objInitChat.producttype;
                            objMob.MobilizationStatusName = objInitChat.MobilizationStatus;
                            mobilizationListDtoList.Add(objMob);
                            break;

                        }
                    }

                }
                return mobilizationListDtoList;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<ApplicationListDto> GetStateWiseApplicationbyUserId(int UserId, string state)
        {
            try
            {
                var applications = _applicationRepository.GetAllList(x => x.CreatorUserId == UserId && x.ScreenStatus.Contains(state)).ToList();

                var objmobilizationsList = ObjectMapper.Map<List<ApplicationListDto>>(applications);

                var initChat = (from mob in _applicationRepository.GetAllList()
                                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                                join mobilization in _mobilizationStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id
                                select new
                                {
                                    mob.Id,
                                    producttype = product.Name,
                                    MobilizationStatus = mobilization.Name,

                                }).ToList();

                List<ApplicationListDto> mobilizationListDtoList = new List<ApplicationListDto>();

                foreach (var objMob in objmobilizationsList)
                {
                    foreach (var objInitChat in initChat)
                    {
                        if (objMob.Id == objInitChat.Id)
                        {
                            objMob.ProductTypeName = objInitChat.producttype;
                            objMob.MobilizationStatusName = objInitChat.MobilizationStatus;
                            mobilizationListDtoList.Add(objMob);
                            break;

                        }
                    }

                }

                var usersTagged = _taggedPortfolioAppService.GetAllTaggedPortfolio().Where(x => x.NewUserId == UserId);

                foreach (var taggedApp in usersTagged)
                {
                    var app = GetApplicationById(taggedApp.ApplicationId);
                    if (app.ScreenStatus.Contains(state))
                    {
                        mobilizationListDtoList.Add(app);

                    }
                }
                //var schedules = _scheduleAppService.GetScheduleList();
                foreach (var mob in mobilizationListDtoList)
                {
                    if (mob.ScreenStatus == ApplicationState.Discrepent)
                    {
                        var discrepentList = _branchManagerActionAppService.getDiscrepentedForms(mob.Id);
                        mob.DescripentScreens = discrepentList;
                    }

                    //var schedule = schedules.Result.Where(x => x.ApplicationId == mob.Id).FirstOrDefault();
                    //if (schedule != null)
                    //{
                    //    var lastUnpaid = schedule.installmentList.Where(y => y.isPaid != true).FirstOrDefault();
                    //    if (lastUnpaid != null)
                    //    {
                    //        mob.DueDate = lastUnpaid.InstallmentDueDate;
                    //    }

                    //}
                }

                return mobilizationListDtoList;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }


        public List<ApplicationListDto> GetDescripentApplicationbyUserId(int UserId)
        {
            try
            {
                var applications = _applicationRepository.GetAllIncluding(x => x.DescripentScreens).Where(x => x.CreatorUserId == UserId && x.ScreenStatus.Contains("Descripent")).ToList();

                var objmobilizationsList = ObjectMapper.Map<List<ApplicationListDto>>(applications);

                var initChat = (from mob in _applicationRepository.GetAllList()
                                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                                join mobilization in _mobilizationStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id
                                select new
                                {
                                    mob.Id,
                                    producttype = product.Name,
                                    MobilizationStatus = mobilization.Name,

                                }).ToList();

                List<ApplicationListDto> mobilizationListDtoList = new List<ApplicationListDto>();

                foreach (var objMob in objmobilizationsList)
                {
                    foreach (var objInitChat in initChat)
                    {
                        if (objMob.Id == objInitChat.Id)
                        {
                            objMob.ProductTypeName = objInitChat.producttype;
                            objMob.MobilizationStatusName = objInitChat.MobilizationStatus;
                            mobilizationListDtoList.Add(objMob);
                            break;

                        }
                    }

                }





                return mobilizationListDtoList;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }
        public ApplicationListDto GetDescripentApplicationbyApplicationId(int ApplicationId)
        {
            try
            {
                var applications = _applicationRepository.GetAllIncluding(x => x.DescripentScreens).Where(x => x.Id == ApplicationId).FirstOrDefault();

                var objmobilizationsList = ObjectMapper.Map<ApplicationListDto>(applications);

                return objmobilizationsList;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public DateTime getLastWorkFlowStateDate(int ApplicationId, string State)
        {
            try
            {
                var workflow = _finalWorkflowAppService.GetFinalWorkflowByApplicationId(ApplicationId).Where(x => x.ApplicationState == State).LastOrDefault();

                var objworkflow = ObjectMapper.Map<FinalWorkflowListDto>(workflow);

                if (objworkflow != null)
                {
                    return objworkflow.CreationTime;
                }
                else
                {
                    return new DateTime();
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }

        public List<MobilizationSyncDto> GetMobilizationDataBySDEId(int SDEId)
        {
            try
            {
                List<MobilizationSyncDto> mobilizationList = new List<MobilizationSyncDto>();

                var MobList = _mobilizationRepository.GetAllList(x => x.CreatorUserId == SDEId);
                var applications = _applicationRepository.GetAllList(x => x.CreatorUserId == SDEId && x.ScreenStatus == "In Process");

                foreach (var app in MobList)
                {

                    MobilizationSyncDto mob = new MobilizationSyncDto();
                    mob.ApplicationId = app.Id;
                    mob.ClientName = app.ClientName;
                    mob.SchoolName = app.SchoolName;
                    mob.MobileNo = app.MobileNo;
                    mob.CNICNo = app.CNICNo;
                    mob.Address = app.Address;
                    mob.MobilizationStatus = app.MobilizationStatus;
                    mob.ProductType = app.ProductType;
                    mob.NextMeeting = string.Format("{0:yyyy-MM-dd}", app.NextMeeting);
                    mob.ScreenStatus = app.ScreenStatus;
                    mob.Comments = app.Comments;
                    mob.CreationTime = app.CreationTime;
                    mob.Remarks = app.Remarks;
                    mob.AverageFee = app.AverageFee;
                    mob.PrefixLable = app.PrefixLable;
                    mob.RespondantDesignation = app.RespondantDesignation;
                    mob.ApplicantSource = app.ApplicantSource;
                    mob.PersonNotInterested = app.PersonNotInterested;
                    mob.PrefferedProduct = app.PrefferedProduct;
                    mob.MentionProviderInterest = app.MentionProviderInterest;
                    mob.NoOfStudent = app.NoOfStudent;
                    mob.NoOfStaff = app.NoOfStaff;
                    mob.BuildingStatus = app.BuildingStatus;
                    mob.AreaOfSchoolMarla = app.AreaOfSchoolMarla;

                    mob.MobilizationTableID = app.MobilizationTableID;
                    mob.otherApplicantSource = app.otherApplicantSource;
                    mob.otherNotbeingIntersted = app.otherNotbeingIntersted;
                    mob.otherSchoolBuildingStatus = app.otherSchoolBuildingStatus;
                    mob.interstedOtherProductProvider = app.interstedOtherProductProvider;
                    mob.finalDecisionMonths = app.finalDecisionMonths;
                    mob.PrefferedProduct = app.PrefferedProduct;
                    mob.PrefferedProvider = app.PrefferedProvider;
                    mob.RespondantDesignationOthers = app.RespondantDesignationOthers;
                    mob.InteractionNumber = app.InteractionNumber;
                    mob.isFranchise = app.isFranchise;
                    mob.FranchiserName = app.FranchiserName;
                    mob.OtherSourceIncome = app.OtherSourceIncome;
                    mob.OtherSourceIncomeOthers = app.OtherSourceIncomeOthers;
                    mob.AnyOtherBusiness = app.AnyOtherBusiness;
                    mob.isAvailedLoan = app.isAvailedLoan;
                    mob.AcademicSession = app.AcademicSession;
                    mob.SchoolCategory = app.SchoolCategory;
                    mob.Longitude = app.Longitude;
                    mob.Latitude = app.Latitude;
                    mob.TDSBusinessNature = app.TDSBusinessNature;


                    mob.CreatorUserId = Convert.ToInt64(app.CreatorUserId);

                    mobilizationList.Add(mob);
                }

                foreach (var app in applications)
                {
                    if (app.ScreenStatus == ApplicationState.Created || app.ScreenStatus == ApplicationState.InProcess)
                    {
                        MobilizationSyncDto mob = new MobilizationSyncDto();
                        mob.ApplicationId = app.Id;
                        mob.ClientName = app.ClientName;
                        mob.MobileNo = app.MobileNo;
                        mob.SchoolName = app.SchoolName;
                        mob.CNICNo = app.CNICNo;
                        mob.Address = app.Address;
                        mob.MobilizationStatus = app.MobilizationStatus;
                        mob.ProductType = app.ProductType;
                        mob.NextMeeting = string.Format("{0:yyyy-MM-dd}", app.NextMeeting);
                        mob.ScreenStatus = app.ScreenStatus;
                        mob.Comments = app.Comments;
                        mob.CreationTime = app.CreationTime;
                        mob.Remarks = app.Remarks;
                        mob.AverageFee = app.AverageFee;
                        mob.PrefixLable = app.PrefixLable;
                        mob.RespondantDesignation = app.RespondantDesignation;
                        mob.ApplicantSource = app.ApplicantSource;
                        mob.PersonNotInterested = app.PersonNotInterested;
                        mob.PrefferedProduct = app.InterestOtherProvider;
                        mob.MentionProviderInterest = app.MentionProviderInterest;
                        mob.NoOfStudent = app.NoOfStudent;
                        mob.NoOfStaff = app.NoOfStaff;
                        mob.BuildingStatus = app.BuildingStatus;
                        mob.AreaOfSchoolMarla = app.AreaOfSchoolMarla;
                        mob.CreatorUserId = Convert.ToInt64(app.CreatorUserId);


                        mobilizationList.Add(mob);
                    }
                }

                return mobilizationList;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", application));
            }
        }


        public string setMobilizationRecordId(List<setMobilizationRecordIdDto> records)
        {

            try
            {
                var applicationz = _applicationRepository.GetAllList();
                foreach( var record in records)
                {
                    var app = applicationz.Where(x => x.Id == record.ApplicationId).FirstOrDefault();
                    if(app!=null)
                    {
                        app.MobilizationRecordId=record.mobilizationRecordId;
                        _applicationRepository.Update(app);
                        CurrentUnitOfWork.SaveChanges();
                    }
                }


                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
