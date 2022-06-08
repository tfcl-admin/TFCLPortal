using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;
using TFCLPortal.DynamicDropdowns.CollateralTypes;
using TFCLPortal.DynamicDropdowns.CreditCommettees;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.Genders;
using TFCLPortal.DynamicDropdowns.GenericDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.ICollateralOwnerships;
using TFCLPortal.DynamicDropdowns.LandTypes;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.NatureOfBusinesses;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.PaymentsFrquency;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.DynamicDropdowns.PropertyTypes;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.Qualifications;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.DynamicDropdowns.SchoolClasses;
using TFCLPortal.DynamicDropdowns.SchoolTypes;
using TFCLPortal.DynamicDropdowns.StudentsGender;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.PersonalDetails;
using TFCLPortal.DynamicDropdowns.RespondantDesignations;
using TFCLPortal.DynamicDropdowns.ApplicantSources;
using TFCLPortal.DynamicDropdowns.ReasonForNotBeingInteresteds;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes;
using TFCLPortal.DynamicDropdowns.BuildingStatuses;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.DynamicDropdowns.TDSBusinessNatures;
using TFCLPortal.DynamicDropdowns.ClientStatuses;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.SpouseStatuses;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatoryOthers;
using TFCLPortal.DynamicDropdowns.BusinessNatures;
using TFCLPortal.DynamicDropdowns.ContactPreferences;
using TFCLPortal.DynamicDropdowns.SchoolLevels;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.DynamicDropdowns.LegalStatuses;
using System.Linq;
using TFCLPortal.DynamicDropdowns.ClientBusinessClassifications;
using TFCLPortal.DynamicDropdowns.RelationshipWithApplicants;
using TFCLPortal.DynamicDropdowns.DropdownUpdateStatuses;
using System.Security.Policy;
using TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes;
using TFCLPortal.DynamicDropdowns.NaSourceOfIncomes;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.Banks;
using TFCLPortal.DynamicDropdowns.CreditBureauReporteds;
using TFCLPortal.DynamicDropdowns.AgeOfVehicles;
using TFCLPortal.DynamicDropdowns.BankRatings;
using TFCLPortal.DynamicDropdowns.LoanNatures;
using TFCLPortal.DynamicDropdowns.ApplicantTypes;
using TFCLPortal.DynamicDropdowns.ContactSources;
using TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances;
using TFCLPortal.DynamicDropdowns.InventoryEntrySources;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;
using TFCLPortal.DynamicDropdowns.CompanyTypes;
using TFCLPortal.DynamicDropdowns.BuildingConditions;
using TFCLPortal.DynamicDropdowns.PowerBackups;
using TFCLPortal.DynamicDropdowns.AyasPresents;
using TFCLPortal.DynamicDropdowns.CleanWaters;
using TFCLPortal.DynamicDropdowns.LearningAids;
using TFCLPortal.DynamicDropdowns.TeacherTrainings;
using TFCLPortal.DynamicDropdowns.SecurityGuards;
using TFCLPortal.DynamicDropdowns.FinancialRecords;
using TFCLPortal.DynamicDropdowns.BusinessRadiuses;
using TFCLPortal.DynamicDropdowns.BankingTransactiones;
using TFCLPortal.DynamicDropdowns.PeopleSteals;
using TFCLPortal.DynamicDropdowns.AvoidConflicts;
using TFCLPortal.DynamicDropdowns.BiggestMotivations;
using TFCLPortal.DynamicDropdowns.HopefulFutures;
using TFCLPortal.DynamicDropdowns.DigitalInitiatives;
using TFCLPortal.DynamicDropdowns.TeacherTrainingDays;
using TFCLPortal.DynamicDropdowns.ParentEngagements;
using TFCLPortal.DynamicDropdowns.SpouseFamilyOtherIncomes;
using TFCLPortal.DynamicDropdowns.OtherPaymentBehaviours;
using TFCLPortal.LiabilityTypes;

namespace TFCLPortal.DynamicDropdowns.GenericDropdowns
{
    public class GenericDropdownAppService : TFCLPortalAppServiceBase, IGenericDropdownsAppService
    {
        private readonly ILoanPurposeAppService _loanPurposeAppService;
        private readonly IOwnershipAppService _ownershipAppService;
        private readonly IPaymentFrequencyAppService _paymentFrequencyAppService;
        private readonly IQualificationAppService _qualificationAppService;
        private readonly IApplicantReputationAppService _applicantReputationAppService;
        private readonly IBusinessLegalStatusAppService _businessLegalStatusAppService;
        private readonly ICollateralOwnAppService _collateralOwnAppService;
        private readonly ICollateralTypeAppService _collateralTypeAppService;
        private readonly ICreditCommetteeAppService _creditCommetteeAppService;
        private readonly IFundSourceAppService _fundSourceAppService;
        private readonly IGenderAppService _genderAppService;
        private readonly ILandTypeAppService _landTypeAppService;
        private readonly IMaritalStatusAppService _maritalStatusAppService;
        private readonly IOccupationAppService _occupationAppService;
        private readonly IStudentGenderAppService _studentGenderAppService;
        private readonly IUtilityBillPaymentAppService _utilityBillPaymentAppService;
        private readonly IProvinceAppService _ProvinceAppService;
        private readonly IDistrictAppService _districtAppService;
        private readonly IMobilizationStatusAppService _mobilizationStatusAppService;
        private readonly IProductTypeAppService _productTypeAppService;
        private readonly ISchoolTypeAppService _schoolTypeAppService;
        private readonly IPropertyTypeAppService _propertyTypeAppService;
        private readonly IReferenceCheckAppService _referenceCheckAppService;
        private readonly ISchoolClassAppService _schoolClassAppService;
        private readonly ILoanTenureRequiredAppService _loanTenureRequiredAppService;
        private readonly INatureOfBusinessAppService _natureOfBusinessAppService;
        private readonly IRespondantDesignationAppService _respondantDesignationAppService;
        private readonly IApplicantSourceAppService _applicantSourceAppService;
        private readonly IAcademicSessionAppService _academicSessionAppService;
        private readonly IOtherSourceOfIncomeAppService _otherSourceOfIncomeAppService;
        private readonly IReasonForNotBeingInterestedAppService _reasonForNotBeingInterestedAppService;
        private readonly IBuildingStatusAppService _BuildingStatusAppService;
        private readonly ISchoolCategoryAppService _schoolCategoryAppService;
        private readonly ITDSBusinessNatureAppService _tDSBusinessNatureAppService;
        private readonly IClientStatusAppService _clientStatusAppService;
        private readonly IReasonOfDeclineAppService _reasonOfDeclineAppService;
        private readonly ICreditBureauCheckAppService _creditBureauCheckAppService;
        private readonly ILoanPurposeClassificationAppService _loanPurposeClassificationAppService;
        private readonly ISpouseStatusAppService _spouseStatusAppService;
        private readonly IRentAgreementSignatoryAppService _rentAgreementSignatoryAppService;
        private readonly IRentAgreementSignatoryOtherAppService _rentAgreementSignatoryOtherAppService;
        private readonly IContactPreferenceAppService _contactPreferenceAppService;
        private readonly IBusinessNatureAppService _businessNatureAppService;
        private readonly IBusinessTypeAppService _businessTypeAppService;
        private readonly ILegalStatusAppService _legalStatusAppService;
        private readonly ISchoolLevelAppService _schoolLevelAppService;
        private readonly IRelationshipWithApplicantAppService _relationshipWithApplicantAppService;
        private readonly IClientBusinessClassificationAppService _clientBusinessClassificationAppService;
        private readonly IOtherAssociatedIncomeAppService _otherAssociatedIncomeAppService;
        private readonly INaSourceOfIncomeAppService _naSourceOfIncomeAppService;
        private readonly IDesignationAppService _designationAppService;
        private readonly IAgeOfVehicleAppService _ageOfVehicleAppService;
        private readonly IBankRatingAppService _bankRatingAppService;
        private readonly IBankAppService _bankAppService;
        private readonly ICreditBureauReportedAppService _creditBureauReportedAppService;
        private readonly IApplicantTypeAppService _applicantTypeAppService;
        private readonly IContactSourceAppService _contactSourceAppService;
        private readonly IInventoryRecordMaintenanceAppService _inventoryRecordMaintenanceAppService;
        private readonly IInventoryEntrySourceAppService _inventoryEntrySourceAppService;
        private readonly INatureOfEmploymentAppService _natureOfEmploymentAppService;
        private readonly ICompanyTypeAppService _companyTypeAppService;

        private readonly ILoanNatureAppService _loanNatureAppService;
        private readonly IRepository<LiabilityType> _LiabilityTypeRepository;
        private readonly IRepository<OtherPaymentBehaviour> _OtherPaymentBehaviourRepository;
        private readonly IRepository<DropdownUpdateStatus> _dropdownUpdateStatusesRepository;
        private readonly IRepository<BuildingCondition> _buildingConditionRepository;
        private readonly IRepository<PowerBackup> _powerBackupRepository;
        private readonly IRepository<AyasPresent> _ayasPresentRepository;
        private readonly IRepository<CleanWater> _CleanWaterRepository;
        private readonly IRepository<LearningAid> _LearningAidRepository;
        private readonly IRepository<TeacherTraining> _TeacherTrainingRepository;
        private readonly IRepository<SecurityGuard> _SecurityGuardRepository;
        private readonly IRepository<FinancialRecord> _FinancialRecordRepository;
        private readonly IRepository<BusinessRadius> _BusinessRadiusRepository;
        private readonly IRepository<PeopleSteal> _PeopleStealRepository;
        private readonly IRepository<AvoidConflict> _AvoidConflictRepository;
        private readonly IRepository<BiggestMotivation> _BiggestMotivationRepository;
        private readonly IRepository<HopefulFuture> _HopefulFutureRepository;
        private readonly IRepository<DigitalInitiative> _DigitalInitiativeRepository;
        private readonly IRepository<TeacherTrainingDay> _TeacherTrainingDayRepository;
        private readonly IRepository<BankingTransaction> _bankingTransactionRepository;
        private readonly IRepository<ParentEngagement> _ParentEngagementRepository;
        private readonly IRepository<SpouseFamilyOtherIncome> _SpouseFamilyOtherIncomeRepository;
        public GenericDropdownAppService
        (ILoanPurposeAppService loanPurposeAppService,
            IRepository<LearningAid> LearningAidRepository,
            IRepository<CleanWater> CleanWaterRepository,
            IRepository<TeacherTraining> TeacherTrainingRepository,
            IRepository<SecurityGuard> SecurityGuardRepository,
            IRepository<FinancialRecord> FinancialRecordRepository,
            IRepository<BusinessRadius> BusinessRadiusRepository,
            IRepository<BankingTransaction> BankingTransactionRepository,
               IRepository<PeopleSteal> PeopleStealRepository,
        IRepository<AvoidConflict> AvoidConflictRepository,
        IRepository<BiggestMotivation> BiggestMotivationRepository,
        IRepository<HopefulFuture> HopefulFutureRepository,
        IRepository<DigitalInitiative> DigitalInitiativeRepository,
        IRepository<TeacherTrainingDay> TeacherTrainingDayRepository,
        IRepository<LiabilityType> LiabilityTypeRepository,
        IRepository<ParentEngagement> ParentEngagementRepository,
        IRepository<OtherPaymentBehaviour> OtherPaymentBehaviourRepository,
        IOwnershipAppService ownershipAppService,
            IPaymentFrequencyAppService paymentFrequencyAppService,
            IInventoryRecordMaintenanceAppService inventoryRecordMaintenanceAppService,
            IInventoryEntrySourceAppService inventoryEntrySourceAppService,
            IQualificationAppService qualificationAppService,
            IApplicantReputationAppService applicantReputationAppService,
            IBusinessLegalStatusAppService businessLegalStatusAppService,
            ICollateralOwnAppService collateralOwnAppService,
            INatureOfEmploymentAppService natureOfEmploymentAppService,
            ICompanyTypeAppService companyTypeAppService,
            IApplicantTypeAppService applicantTypeAppService,
            IContactSourceAppService contactSourceAppService,
            ICollateralTypeAppService collateralTypeAppService,
            ICreditCommetteeAppService creditCommetteeAppService,
            IFundSourceAppService fundSourceAppService,
            IGenderAppService genderAppService,
            ILandTypeAppService landTypeAppService,
            IMaritalStatusAppService maritalStatusAppService,
            IOccupationAppService occupationAppService,
            IStudentGenderAppService studentGenderAppService,
            IUtilityBillPaymentAppService utilityBillPaymentAppService,
            IProvinceAppService ProvinceAppService,
            IDistrictAppService districtAppService,
            IMobilizationStatusAppService mobilizationStatusAppService,
            IRespondantDesignationAppService respondantDesignationAppService,
            IProductTypeAppService productTypeAppService,
            ISchoolTypeAppService schoolTypeAppService,
            IPropertyTypeAppService propertyTypeAppService,
            IReferenceCheckAppService referenceCheckAppService,
            ISchoolClassAppService schoolClassAppService,
            ILoanTenureRequiredAppService loanTenureRequiredAppService,
            IApplicantSourceAppService applicantSourceAppService,
            IAcademicSessionAppService academicSessionAppService,
            IReasonForNotBeingInterestedAppService reasonForNotBeingInterestedAppService,
            IOtherSourceOfIncomeAppService otherSourceOfIncomeAppService,
            IBuildingStatusAppService BuildingStatusAppService,
            ISchoolCategoryAppService schoolCategoryAppService,
            ITDSBusinessNatureAppService tDSBusinessNatureAppService,
            IClientStatusAppService clientStatusAppService,
            IReasonOfDeclineAppService reasonOfDeclineAppService,
            IDesignationAppService designationAppService,
            ILoanNatureAppService loanNatureAppService,
            ICreditBureauCheckAppService creditBureauCheckAppService,
            ILoanPurposeClassificationAppService loanPurposeClassificationAppService,
            ISpouseStatusAppService spouseStatusAppService,
            IRentAgreementSignatoryOtherAppService rentAgreementSignatoryOtherAppService,
            IRentAgreementSignatoryAppService rentAgreementSignatoryAppService,
            IBusinessNatureAppService businessNatureAppService,
            IContactPreferenceAppService contactPreferenceAppService,
            IBusinessTypeAppService businessTypeAppService,
            ILegalStatusAppService legalStatusAppService,
            ISchoolLevelAppService schoolLevelAppService,
            IRepository<DropdownUpdateStatus> dropdownUpdateStatusesRepository,
            IRelationshipWithApplicantAppService relationshipWithApplicantAppService,
            IOtherAssociatedIncomeAppService otherAssociatedIncomeAppService,
            INaSourceOfIncomeAppService naSourceOfIncomeAppService,
            IBankAppService bankAppService,
            IAgeOfVehicleAppService ageOfVehicleAppService,
            IRepository<BuildingCondition> buildingConditionRepository,
            IRepository<AyasPresent> ayasPresentRepository,
            IRepository<PowerBackup> powerBackupRepository,
            IRepository<SpouseFamilyOtherIncome> SpouseFamilyOtherIncomeRepository,
            IBankRatingAppService bankRatingAppService,
            ICreditBureauReportedAppService creditBureauReportedAppService,
            IClientBusinessClassificationAppService clientBusinessClassificationAppService,
            INatureOfBusinessAppService natureOfBusinessAppService)
        {
            _SpouseFamilyOtherIncomeRepository = SpouseFamilyOtherIncomeRepository;
            _powerBackupRepository = powerBackupRepository;
            _CleanWaterRepository = CleanWaterRepository;
            _loanPurposeAppService = loanPurposeAppService;
            _ownershipAppService = ownershipAppService;
            _paymentFrequencyAppService = paymentFrequencyAppService;
            _inventoryRecordMaintenanceAppService = inventoryRecordMaintenanceAppService;
            _inventoryEntrySourceAppService = inventoryEntrySourceAppService;
            _qualificationAppService = qualificationAppService;
            _applicantReputationAppService = applicantReputationAppService;
            _businessLegalStatusAppService = businessLegalStatusAppService;
            _collateralOwnAppService = collateralOwnAppService;
            _collateralTypeAppService = collateralTypeAppService;
            _creditCommetteeAppService = creditCommetteeAppService;
            _fundSourceAppService = fundSourceAppService;
            _genderAppService = genderAppService;
            _landTypeAppService = landTypeAppService;
            _natureOfEmploymentAppService = natureOfEmploymentAppService;
            _maritalStatusAppService = maritalStatusAppService;
            _loanNatureAppService = loanNatureAppService;
            _OtherPaymentBehaviourRepository = OtherPaymentBehaviourRepository;
            _LiabilityTypeRepository = LiabilityTypeRepository;
            _applicantTypeAppService = applicantTypeAppService;
            _contactSourceAppService = contactSourceAppService;
            _occupationAppService = occupationAppService;
            _studentGenderAppService = studentGenderAppService;
            _companyTypeAppService = companyTypeAppService;
            _utilityBillPaymentAppService = utilityBillPaymentAppService;
            _ProvinceAppService = ProvinceAppService;
            _districtAppService = districtAppService;
            _mobilizationStatusAppService = mobilizationStatusAppService;
            _productTypeAppService = productTypeAppService;
            _schoolTypeAppService = schoolTypeAppService;
            _propertyTypeAppService = propertyTypeAppService;
            _referenceCheckAppService = referenceCheckAppService;
            _schoolClassAppService = schoolClassAppService;
            _loanTenureRequiredAppService = loanTenureRequiredAppService;
            _natureOfBusinessAppService = natureOfBusinessAppService;
            _respondantDesignationAppService = respondantDesignationAppService;
            _applicantSourceAppService = applicantSourceAppService;
            _reasonForNotBeingInterestedAppService = reasonForNotBeingInterestedAppService;
            _academicSessionAppService = academicSessionAppService;
            _otherSourceOfIncomeAppService = otherSourceOfIncomeAppService;
            _BuildingStatusAppService = BuildingStatusAppService;
            _schoolCategoryAppService = schoolCategoryAppService;
            _tDSBusinessNatureAppService = tDSBusinessNatureAppService;
            _clientStatusAppService = clientStatusAppService;
            _reasonOfDeclineAppService = reasonOfDeclineAppService;
            _creditBureauCheckAppService = creditBureauCheckAppService;
            _loanPurposeClassificationAppService = loanPurposeClassificationAppService;
            _spouseStatusAppService = spouseStatusAppService;
            _rentAgreementSignatoryAppService = rentAgreementSignatoryAppService;
            _businessNatureAppService = businessNatureAppService;
            _rentAgreementSignatoryOtherAppService = rentAgreementSignatoryOtherAppService;
            _contactPreferenceAppService = contactPreferenceAppService;
            _businessTypeAppService = businessTypeAppService;
            _legalStatusAppService = legalStatusAppService;
            _schoolLevelAppService = schoolLevelAppService;
            _clientBusinessClassificationAppService = clientBusinessClassificationAppService;
            _relationshipWithApplicantAppService = relationshipWithApplicantAppService;
            _dropdownUpdateStatusesRepository = dropdownUpdateStatusesRepository;
            _otherAssociatedIncomeAppService = otherAssociatedIncomeAppService;
            _naSourceOfIncomeAppService = naSourceOfIncomeAppService;
            _designationAppService = designationAppService;
            _bankAppService = bankAppService;
            _creditBureauReportedAppService = creditBureauReportedAppService;
            _ageOfVehicleAppService = ageOfVehicleAppService;
            _bankRatingAppService = bankRatingAppService;
            _buildingConditionRepository = buildingConditionRepository;
            _ayasPresentRepository = ayasPresentRepository;
            _LearningAidRepository = LearningAidRepository;
            _TeacherTrainingRepository = TeacherTrainingRepository;
            _SecurityGuardRepository = SecurityGuardRepository;
            _FinancialRecordRepository = FinancialRecordRepository;
            _BusinessRadiusRepository = BusinessRadiusRepository;
            _bankingTransactionRepository = BankingTransactionRepository;
            _PeopleStealRepository = PeopleStealRepository;
            _AvoidConflictRepository = AvoidConflictRepository;
            _BiggestMotivationRepository = BiggestMotivationRepository;
            _HopefulFutureRepository = HopefulFutureRepository;
            _DigitalInitiativeRepository = DigitalInitiativeRepository;
            _TeacherTrainingDayRepository = TeacherTrainingDayRepository;
            _ParentEngagementRepository = ParentEngagementRepository;
        }

        public async Task<GenericDropdownDto> GetAllDropdownsDataAsync()
        {
            try
            {

                var loanList = _loanPurposeAppService.GetAllList();//.OrderBy(x => x.Name);
                var loanPurposeListDtos = ObjectMapper.Map<List<LoanPurposeListDto>>(loanList);

                var ownerships = _ownershipAppService.GetAllList();//.OrderBy(x => x.Name);
                var ownershipStatusListDtos = ObjectMapper.Map<List<OwnershipStatusListDto>>(ownerships);
                var BusinessPlaceOwnershipStatusListDtos = ObjectMapper.Map<List<OwnershipStatusListDto>>(ownerships);

                var payments = _paymentFrequencyAppService.GetAllList();//.OrderBy(x => x.Name);
                var paymentFrequencyListDtos = ObjectMapper.Map<List<PaymentFrequencyListDto>>(payments);

                var qualifications = _qualificationAppService.GetAllList();//.OrderBy(x => x.Name);
                var qualificationListDtos = ObjectMapper.Map<List<QualificationListDto>>(qualifications);

                var itemToRemoveInQualification = qualificationListDtos.Where(x => x.Id == 8).Single();
                qualificationListDtos.Remove(itemToRemoveInQualification);
                qualificationListDtos.Add(itemToRemoveInQualification);

                var applicantReputations = _applicantReputationAppService.GetAllList();//.OrderBy(x => x.Name);
                var applicantReputationListDtos = ObjectMapper.Map<List<ApplicantReputationListDto>>(applicantReputations);


                var businessLegalStatuses = _businessLegalStatusAppService.GetAllList();//.OrderBy(x=>x.Name);
                var businessLegalStatusListDtos = ObjectMapper.Map<List<BusinessLegalStatusListDto>>(businessLegalStatuses);

                var itemToRemoveInbusinessLegal = businessLegalStatusListDtos.Where(x => x.Id == 3).Single();
                businessLegalStatusListDtos.Remove(itemToRemoveInbusinessLegal);
                businessLegalStatusListDtos.Add(itemToRemoveInbusinessLegal);


                var collateralTypeLists = _collateralTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var collateralTypeListDtos = ObjectMapper.Map<List<CollateralTypeListDto>>(collateralTypeLists);

                var collateralOwnerships = _collateralOwnAppService.GetAllList();//.OrderBy(x => x.Name);
                var collateralOwnershipListDtos = ObjectMapper.Map<List<CollateralOwnershipListDto>>(collateralOwnerships);


                var creditCommettees = _creditCommetteeAppService.GetAllList();//.OrderBy(x => x.Name);
                var creditCommetteeListDtos = ObjectMapper.Map<List<CreditCommetteeListDto>>(creditCommettees);

                var fundSources = _fundSourceAppService.GetAllList();//.OrderBy(x => x.Name);
                var fundSourceListDtos = ObjectMapper.Map<List<FundSourceListDto>>(fundSources);

                var genders = _genderAppService.GetAllList();//.OrderBy(x => x.Name);
                var genderListDtos = ObjectMapper.Map<List<GenderListDto>>(genders);

                var landTypes = _landTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var landTypeListDtos = ObjectMapper.Map<List<LandTypeListDto>>(landTypes);

                var maritalStatuses = _maritalStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var maritalStatusDtos = ObjectMapper.Map<List<MaritalStatusListDto>>(maritalStatuses);

                var occupations = _occupationAppService.GetAllList();//.OrderBy(x => x.Name);
                var occupationListDtos = ObjectMapper.Map<List<OccupationListDto>>(occupations);

                var itemToRemoveInoccupations = occupationListDtos.Where(x => x.Id == 5).Single();
                occupationListDtos.Remove(itemToRemoveInoccupations);
                occupationListDtos.Add(itemToRemoveInoccupations);

                itemToRemoveInoccupations = occupationListDtos.Where(x => x.Id == 9).Single();
                occupationListDtos.Remove(itemToRemoveInoccupations);
                occupationListDtos.Add(itemToRemoveInoccupations);

                var studentGenders = _studentGenderAppService.GetAllList();//.OrderBy(x => x.Name);
                var studentGenderListDtos = ObjectMapper.Map<List<StudentGenderListDto>>(studentGenders);

                var utilityBills = _utilityBillPaymentAppService.GetAllList();//.OrderBy(x => x.Name);
                var utilityBillPaymentListDtos = ObjectMapper.Map<List<UtilityBillPaymentListDto>>(utilityBills);

                var province = _ProvinceAppService.GetAllList();//.OrderBy(x => x.Name);
                var provinceListDtos = ObjectMapper.Map<List<ProvinceListDto>>(province);

                var district = _districtAppService.GetAllList();//.OrderBy(x => x.Name);
                var districtListDtos = ObjectMapper.Map<List<DistrictListDto>>(district);

                var mobilization = _mobilizationStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var mobilizationDtos = ObjectMapper.Map<List<MobilizationStatusListDto>>(mobilization);

                //NEW DROPDOWN API Addition Start
                var respondantDesignation = _respondantDesignationAppService.GetAllList();//.OrderBy(x => x.Name);
                var respondantDesignationDtos = ObjectMapper.Map<List<RespondantDesignationListDto>>(respondantDesignation);

                var applicantSource = _applicantSourceAppService.GetAllList();//.OrderBy(x => x.Name);
                var applicantSourceDtos = ObjectMapper.Map<List<ApplicantSourceListDto>>(applicantSource);

                var ReasonForNotBeingInterested = _reasonForNotBeingInterestedAppService.GetAllList();//.OrderBy(x => x.Name);
                var ReasonForNotBeingInterestedDtos = ObjectMapper.Map<List<ReasonForNotBeingInterestedListDto>>(ReasonForNotBeingInterested);

                var AcademicSession = _academicSessionAppService.GetAllList();//.OrderBy(x => x.Name);
                var AcademicSessionDtos = ObjectMapper.Map<List<AcademicSessionListDto>>(AcademicSession);

                var OtherSourceOfIncome = _otherSourceOfIncomeAppService.GetAllList();//.OrderBy(x => x.Name);
                var OtherSourceOfIncomeDtos = ObjectMapper.Map<List<OtherSourceOfIncomeListDto>>(OtherSourceOfIncome);

                var NaSourceOfIncome = _naSourceOfIncomeAppService.GetAllList();//.OrderBy(x => x.Name);
                var NaSourceOfIncomeDtos = ObjectMapper.Map<List<NaSourceOfIncomeListDto>>(NaSourceOfIncome);

                var BuildingStatus = _BuildingStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var BuildingStatusDtos = ObjectMapper.Map<List<BuildingStatusListDto>>(BuildingStatus);

                var NatureOfEmployment = _natureOfEmploymentAppService.GetAllList();//.OrderBy(x => x.Name);
                var NatureOfEmploymentDtos = ObjectMapper.Map<List<NatureOfEmploymentListDto>>(NatureOfEmployment);

                var CompanyType = _companyTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var CompanyTypeDtos = ObjectMapper.Map<List<CompanyTypeListDto>>(CompanyType);

                var SchoolCategory = _schoolCategoryAppService.GetAllList();//.OrderBy(x => x.Name);
                var SchoolCategoryDtos = ObjectMapper.Map<List<SchoolCategoryListDto>>(SchoolCategory);

                var TDSBusinessNature = _tDSBusinessNatureAppService.GetAllList();//.OrderBy(x => x.Name);
                var TDSBusinessNatureDtos = ObjectMapper.Map<List<TDSBusinessNatureListDto>>(TDSBusinessNature);

                var ClientStatus = _clientStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var ClientStatusDtos = ObjectMapper.Map<List<ClientStatusListDto>>(ClientStatus);

                var ReasonOfDeclines = _reasonOfDeclineAppService.GetAllList();//.OrderBy(x => x.Name);
                var ReasonOfDeclineDtos = ObjectMapper.Map<List<ReasonOfDeclineListDto>>(ReasonOfDeclines);

                var CreditBureauChecks = _creditBureauCheckAppService.GetAllList();//.OrderBy(x => x.Name);
                var CreditBureauCheckDtos = ObjectMapper.Map<List<CreditBureauCheckListDto>>(CreditBureauChecks);

                var LoanPurposeClassifications = _loanPurposeClassificationAppService.GetAllList();//.OrderBy(x => x.Name);
                var LoanPurposeClassificationDtos = ObjectMapper.Map<List<LoanPurposeClassificationListDto>>(LoanPurposeClassifications);

                var SpouseStatuses = _spouseStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var SpouseStatusDtos = ObjectMapper.Map<List<SpouseStatusListDto>>(SpouseStatuses);

                var relationshipWithApplicant = _relationshipWithApplicantAppService.GetAllList();//.OrderBy(x => x.Name);
                var relationshipWithApplicantDtos = ObjectMapper.Map<List<RelationshipWithApplicantListDto>>(relationshipWithApplicant);

                var bankRatings = _bankRatingAppService.GetAllList();//.OrderBy(x => x.Name);
                var bankRatingDtos = ObjectMapper.Map<List<BankRatingListDto>>(bankRatings);

                var ageOfVehicles = _ageOfVehicleAppService.GetAllList();//.OrderBy(x => x.Name);
                var ageOfVehicleDtos = ObjectMapper.Map<List<AgeOfVehicleListDto>>(ageOfVehicles);


                var loanNatures = _loanNatureAppService.GetAllList();//.OrderBy(x => x.Name);
                var loanNatureDtos = ObjectMapper.Map<List<LoanNatureListDto>>(loanNatures);

                //NEW DROPDOWN API Addition End


                var productType = _productTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var productTypeListDtos = ObjectMapper.Map<List<ProductTypeListDto>>(productType);

                var schoolType = _schoolTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var schoolTypeListDtos = ObjectMapper.Map<List<SchoolTypeListDto>>(schoolType);

                var propertyType = _propertyTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var propertyTypeListDtos = ObjectMapper.Map<List<PropertyTypeListDto>>(propertyType);

                var ReferenceChecks = _referenceCheckAppService.GetAllList();//.OrderBy(x => x.Name);
                var ReferenceCheckListDtos = ObjectMapper.Map<List<ReferenceCheckListDto>>(ReferenceChecks);

                var schoolClass = _schoolClassAppService.GetAllList();//.OrderBy(x => x.Name);
                var SchoolClassListDtos = ObjectMapper.Map<List<SchoolClassListDto>>(schoolClass);

                var loanTenure = _loanTenureRequiredAppService.GetAllList();//.OrderBy(x => x.Name);
                var loanTenureListDtos = ObjectMapper.Map<List<LoanTenureRequiredListDto>>(loanTenure);

                var naturebusiness = _natureOfBusinessAppService.GetAllList();//.OrderBy(x => x.Name);
                var BusinessListDtos = ObjectMapper.Map<List<NatureOfBusinessListDto>>(naturebusiness);

                var RentAgreementSignatory = _rentAgreementSignatoryAppService.GetAllList();//.OrderBy(x => x.Name);
                var RentAgreementSignatoryListDtos = ObjectMapper.Map<List<RentAgreementSignatoryListDto>>(RentAgreementSignatory);

                var RentAgreementSignatoryOther = _rentAgreementSignatoryOtherAppService.GetAllList();//.OrderBy(x => x.Name);
                var RentAgreementSignatoryOtherListDtos = ObjectMapper.Map<List<RentAgreementSignatoryOtherListDto>>(RentAgreementSignatoryOther);

                var BusinessNature = _businessNatureAppService.GetAllList();//.OrderBy(x => x.Name);
                var BusinessNatureListDtos = ObjectMapper.Map<List<BusinessNatureListDto>>(BusinessNature);

                var ContactPreference = _contactPreferenceAppService.GetAllList();//.OrderBy(x => x.Name);
                var ContactPreferenceListDtos = ObjectMapper.Map<List<ContactPreferencesListDto>>(ContactPreference);

                var SchoolLevel = _schoolLevelAppService.GetAllList();//.OrderBy(x => x.Name);
                var SchoolLevelListDtos = ObjectMapper.Map<List<SchoolLevelListDto>>(SchoolLevel);

                var BusinessType = _businessTypeAppService.GetAllList();//.OrderBy(x => x.Name);
                var BusinessTypeListDtos = ObjectMapper.Map<List<BusinessTypeListDto>>(BusinessType);

                var LegalStatus = _legalStatusAppService.GetAllList();//.OrderBy(x => x.Name);
                var LegalStatusListDtos = ObjectMapper.Map<List<LegalStatusListDto>>(LegalStatus);

                var ClientBusinessClassifications = _clientBusinessClassificationAppService.GetAllList();//.OrderBy(x => x.Name);
                var ClientBusinessClassificationListDtos = ObjectMapper.Map<List<ClientBusinessClassificationListDto>>(ClientBusinessClassifications);

                var OtherAssociatedIncomes = _otherAssociatedIncomeAppService.GetAllList();//.OrderBy(x => x.Name);
                var OtherAssociatedIncomesListDtos = ObjectMapper.Map<List<OtherAssociatedIncomeListDto>>(OtherAssociatedIncomes);

                var NumbersListDtos = ObjectMapper.Map<List<NumbersListDto>>(GetNumbersListDtos());
                var PercentageListDtos = ObjectMapper.Map<List<NumbersListDto>>(GetPercentageListDtos());
                var AvgFeeListDtos = ObjectMapper.Map<List<NumbersListDto>>(GetAvgFeeListDtos());

                var designations = _designationAppService.GetAllList();//.OrderBy(x => x.Name);
                var designationListDtos = ObjectMapper.Map<List<DesignationListDto>>(designations);

                var banks = _bankAppService.GetAllList().OrderBy(x => x.Name);
                var bankListForExposureDtos = ObjectMapper.Map<List<BankListDto>>(banks);

                var applicantTypes = _applicantTypeAppService.GetAllList().OrderBy(x => x.Name);
                var applicantTypesDtos = ObjectMapper.Map<List<ApplicantTypeListDto>>(applicantTypes);

                var contactSources = _contactSourceAppService.GetAllList().OrderBy(x => x.Name);
                var contactSourceDtos = ObjectMapper.Map<List<ContactSourceListDto>>(contactSources);

                var bankListForBankDetails = ObjectMapper.Map<List<BankListDto>>(banks);
                var itemToRemoveInbanks = bankListForBankDetails.Where(x => x.Name == "Others").Single();
                bankListForBankDetails.Remove(itemToRemoveInbanks);

                var itemToRemoveInbank = bankListForExposureDtos.Where(x => x.Name == "Others").Single();
                bankListForExposureDtos.Remove(itemToRemoveInbank);
                bankListForExposureDtos.Add(itemToRemoveInbank);

                var bankListDtos = bankListForBankDetails;

                //bankListForExposureDtos.Add(itemToRemoveInbanks);


                var creditBureauReporteds = _creditBureauReportedAppService.GetAllList();//.OrderBy(x => x.Name);
                var creditBureauReportedListDtos = ObjectMapper.Map<List<CreditBureauReportedListDto>>(creditBureauReporteds);


                var EntrySources = _inventoryEntrySourceAppService.GetAllList();
                var EntrySourcesDto = ObjectMapper.Map<List<InventoryEntrySourceListDto>>(EntrySources);

                var RecordMaintenances = _inventoryRecordMaintenanceAppService.GetAllList();
                var RecordMaintenanceDto = ObjectMapper.Map<List<InventoryRecordMaintenanceListDto>>(RecordMaintenances);


                //New Added for Mobilization
                //var loanList = _loanPurposeAppService.GetAllList();
                //var loanPurposeListDtos = ObjectMapper.Map<List<RespondantDesignationDto>>(loanList);

                GenericDropdownDto genericDropdownDto = new GenericDropdownDto();
                genericDropdownDto.loanPurposeLists = loanPurposeListDtos;
                genericDropdownDto.OwnershipStatusLists = ownershipStatusListDtos;

                var itemToRemove = BusinessPlaceOwnershipStatusListDtos.Where(x => x.Id == 4).Single();
                BusinessPlaceOwnershipStatusListDtos.Remove(itemToRemove);
                genericDropdownDto.BusinessPlaceOwnershipStatusLists = BusinessPlaceOwnershipStatusListDtos;

                genericDropdownDto.paymentFrequencyLists = paymentFrequencyListDtos;
                genericDropdownDto.qualificationLists = qualificationListDtos;
                genericDropdownDto.applicantReputationLists = applicantReputationListDtos;
                genericDropdownDto.businessLegalStatusLists = businessLegalStatusListDtos;
                genericDropdownDto.collateralTypeLists = collateralTypeListDtos;
                genericDropdownDto.collateralOwnershipLists = collateralOwnershipListDtos;
                genericDropdownDto.creditCommetteeLists = creditCommetteeListDtos;
                genericDropdownDto.fundSourceLists = fundSourceListDtos;
                genericDropdownDto.genderLists = genderListDtos;
                genericDropdownDto.landTypeLists = landTypeListDtos;
                genericDropdownDto.maritalStatusLists = maritalStatusDtos;
                genericDropdownDto.occupationLists = occupationListDtos;
                genericDropdownDto.studentGenderLists = studentGenderListDtos;
                genericDropdownDto.utilityBillPaymentLists = utilityBillPaymentListDtos;
                genericDropdownDto.ProvinceLists = provinceListDtos;
                genericDropdownDto.districtLists = districtListDtos;
                genericDropdownDto.MobilizationStatusLists = mobilizationDtos;
                genericDropdownDto.ProductTypeLists = productTypeListDtos;
                genericDropdownDto.SchoolTypeLists = schoolTypeListDtos;
                genericDropdownDto.PropertyTypeLists = propertyTypeListDtos;
                genericDropdownDto.ReferenceCheckLists = ReferenceCheckListDtos;
                genericDropdownDto.SchoolClassLists = SchoolClassListDtos;
                genericDropdownDto.loanTenureRequired = loanTenureListDtos;
                genericDropdownDto.NatureOfBusinessLists = BusinessListDtos;
                genericDropdownDto.RespondantDesignations = respondantDesignationDtos;
                genericDropdownDto.ApplicantSources = applicantSourceDtos;
                genericDropdownDto.reasonForNotBeingInteresteds = ReasonForNotBeingInterestedDtos;
                genericDropdownDto.academicSessions = AcademicSessionDtos;
                genericDropdownDto.OtherSourceOfIncomes = OtherSourceOfIncomeDtos;
                genericDropdownDto.BuildingStatuses = BuildingStatusDtos;
                genericDropdownDto.schoolCategories = SchoolCategoryDtos;
                genericDropdownDto.tDSBusinessNatures = TDSBusinessNatureDtos;
                genericDropdownDto.clientStatuses = ClientStatusDtos;
                genericDropdownDto.reasonOfDeclines = ReasonOfDeclineDtos;
                genericDropdownDto.creditBureauChecks = CreditBureauCheckDtos;
                genericDropdownDto.loanPurposeClassifications = LoanPurposeClassificationDtos;
                genericDropdownDto.SpouseStatuses = SpouseStatusDtos;
                genericDropdownDto.rentAgreementSignatories = RentAgreementSignatoryListDtos;
                genericDropdownDto.rentAgreementSignatoryOthers = RentAgreementSignatoryOtherListDtos;
                genericDropdownDto.businessNatures = BusinessNatureListDtos;
                genericDropdownDto.contactPreferences = ContactPreferenceListDtos;
                genericDropdownDto.legalStatuses = LegalStatusListDtos;
                genericDropdownDto.businessTypes = BusinessTypeListDtos;
                genericDropdownDto.schoolLevels = SchoolLevelListDtos;
                genericDropdownDto.NumbersLists = NumbersListDtos;
                genericDropdownDto.PercentageLists = PercentageListDtos;
                genericDropdownDto.clientBusinessClassifications = ClientBusinessClassificationListDtos;
                genericDropdownDto.relationshipWithApplicants = relationshipWithApplicantDtos;
                genericDropdownDto.OtherAssociatedIncomes = OtherAssociatedIncomesListDtos;
                genericDropdownDto.naSourceOfIncomes = NaSourceOfIncomeDtos;
                genericDropdownDto.Designations = designationListDtos;
                genericDropdownDto.Banks = bankListDtos;
                genericDropdownDto.BanksForExposure = bankListForExposureDtos;
                genericDropdownDto.CreditBureauReporteds = creditBureauReportedListDtos;
                genericDropdownDto.BankRatings = bankRatingDtos;
                genericDropdownDto.ageOfVehicles = ageOfVehicleDtos;
                genericDropdownDto.loanNatures = loanNatureDtos;
                genericDropdownDto.applicantTypes = applicantTypesDtos;
                genericDropdownDto.contactSources = contactSourceDtos;
                genericDropdownDto.inventoryEntrySources = EntrySourcesDto;
                genericDropdownDto.inventoryRecordMaintenances = RecordMaintenanceDto;
                genericDropdownDto.AvgFeeLists = AvgFeeListDtos;
                genericDropdownDto.CompanyTypes = CompanyTypeDtos;
                genericDropdownDto.NatureOfEmployments = NatureOfEmploymentDtos;

                genericDropdownDto.BuildingConditionsRep = _buildingConditionRepository.GetAllList();
                genericDropdownDto.PowerBackupRep = _powerBackupRepository.GetAllList();
                genericDropdownDto.AyasPresentRep = _ayasPresentRepository.GetAllList();
                genericDropdownDto.CleanWaterRep = _CleanWaterRepository.GetAllList();
                genericDropdownDto.LearningAidRep = _LearningAidRepository.GetAllList();
                genericDropdownDto.TeacherTrainingRep = _TeacherTrainingRepository.GetAllList();
                genericDropdownDto.SecurityGuardRep = _SecurityGuardRepository.GetAllList();
                genericDropdownDto.FinancialRecordRep = _FinancialRecordRepository.GetAllList();
                genericDropdownDto.BusinessRadiusRep = _BusinessRadiusRepository.GetAllList();
                genericDropdownDto.BankingTransactionRep = _bankingTransactionRepository.GetAllList();
                genericDropdownDto.PeopleStealRep = _PeopleStealRepository.GetAllList();
                genericDropdownDto.AvoidConflictRep = _AvoidConflictRepository.GetAllList();
                genericDropdownDto.BiggestMotivationRep = _BiggestMotivationRepository.GetAllList();
                genericDropdownDto.HopefulFutureRep = _HopefulFutureRepository.GetAllList();
                genericDropdownDto.DigitalInitiativeRep = _DigitalInitiativeRepository.GetAllList();
                genericDropdownDto.TeacherTrainingDayRep = _TeacherTrainingDayRepository.GetAllList();
                genericDropdownDto.ParentEngagementRep = _ParentEngagementRepository.GetAllList();
                genericDropdownDto.SpouseFamilyOtherIncomeRep = _SpouseFamilyOtherIncomeRepository.GetAllList();
                genericDropdownDto.OtherPaymentBehaviourRep = _OtherPaymentBehaviourRepository.GetAllList();
                genericDropdownDto.LiabilityTypeRep = _LiabilityTypeRepository.GetAllList();
                //new Mobiization Dropdowns


                return genericDropdownDto;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Generic"));
            }
        }

        public string GetDropdownUpdateStatus()
        {
            string response = "";

            var statuses = _dropdownUpdateStatusesRepository.GetAllList();

            response = statuses[0].UpdateStatus.ToString();

            return response;

        }

        public List<NumbersListDto> GetPercentageListDtos()
        {
            List<NumbersListDto> numbersList = new List<NumbersListDto>();
            for (int i = 0; i <= 20; i++)
            {
                NumbersListDto n = new NumbersListDto();
                n.Id = i + 1;
                n.name = (i * 5).ToString() + "%";
                numbersList.Add(n);
            }

            NumbersListDto NA = new NumbersListDto();
            NA.Id = 22;
            NA.name = "N/A";
            numbersList.Add(NA);

            return numbersList;
        }

        public List<NumbersListDto> GetAvgFeeListDtos()
        {
            List<NumbersListDto> numbersList = new List<NumbersListDto>();

            NumbersListDto NA = new NumbersListDto();
            NA.Id = 1;
            NA.name = "0 to 500";
            numbersList.Add(NA);

            NA = new NumbersListDto();
            NA.Id = 2;
            NA.name = "501 to 1,000";
            numbersList.Add(NA);

            NA = new NumbersListDto();
            NA.Id = 3;
            NA.name = "1,001 to 1,500";
            numbersList.Add(NA);

            NA = new NumbersListDto();
            NA.Id = 4;
            NA.name = "1,501 to 2,500";
            numbersList.Add(NA);

            NA = new NumbersListDto();
            NA.Id = 5;
            NA.name = "2,500+";
            numbersList.Add(NA);

            return numbersList;
        }

        public List<NumbersListDto> GetNumbersListDtos()
        {
            List<NumbersListDto> numbersList = new List<NumbersListDto>();

            for (int i = 0; i <= 40; i++)
            {
                NumbersListDto n = new NumbersListDto();
                n.Id = i + 1;
                n.name = i.ToString();
                numbersList.Add(n);
            }

            NumbersListDto NA = new NumbersListDto();
            NA.Id = 42;
            NA.name = "N/A";
            numbersList.Add(NA);


            return numbersList;
        }

        public string ToggleDropdownUpdateStatus()
        {
            string response = "";

            try
            {
                var statuses = _dropdownUpdateStatusesRepository.GetAllList().Where(x => x.Id == 1).SingleOrDefault();
                var statusObj = ObjectMapper.Map<DropdownUpdateStatus>(statuses);

                if (statusObj.UpdateStatus)
                {
                    statusObj.UpdateStatus = false;
                }
                else
                {
                    statusObj.UpdateStatus = true;
                }
                var result = _dropdownUpdateStatusesRepository.Update(statusObj);

                CurrentUnitOfWork.SaveChanges();

                response = "Success";
            }
            catch
            {
                response = "Error";
            }


            return response;
        }
    }
}
