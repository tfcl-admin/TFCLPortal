using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.AyasPresents;
using TFCLPortal.DynamicDropdowns.BuildingConditions;
using TFCLPortal.DynamicDropdowns.CompanyTypes;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;
using TFCLPortal.DynamicDropdowns.PowerBackups;
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

namespace TFCLPortal.DynamicDropdowns.GenericDropdowns.Dto
{
    public class GenericDropdownDto
    {
        public List<LoanPurposeListDto> loanPurposeLists { get; set; }
        //public List<LoanPurpose> loanPurposeRep { get; set; }
        public List<OwnershipStatusListDto> OwnershipStatusLists { get; set; }
        public List<OwnershipStatusListDto> BusinessPlaceOwnershipStatusLists { get; set; }
        public List<PaymentFrequencyListDto> paymentFrequencyLists { get; set; }
        public List<QualificationListDto> qualificationLists { get; set; }
        public List<ApplicantReputationListDto> applicantReputationLists { get; set; }
        public List<BusinessLegalStatusListDto> businessLegalStatusLists { get; set; }

        public List<CollateralTypeListDto> collateralTypeLists { get; set; }
        public List<CollateralOwnershipListDto> collateralOwnershipLists { get; set; }

        public List<CreditCommetteeListDto> creditCommetteeLists { get; set; }
        public List<FundSourceListDto> fundSourceLists { get; set; }

        public List<GenderListDto> genderLists { get; set; }

        public List<LandTypeListDto> landTypeLists { get; set; }

        public List<MaritalStatusListDto> maritalStatusLists { get; set; }
        public List<OccupationListDto> occupationLists { get; set; }

        public List<StudentGenderListDto> studentGenderLists { get; set; }

        public List<UtilityBillPaymentListDto> utilityBillPaymentLists { get; set; }
        public List<ProvinceListDto> ProvinceLists { get; set; }
        public List<DistrictListDto> districtLists { get; set; }
        public List<MobilizationStatusListDto> MobilizationStatusLists { get; set; }
        public List<ProductTypeListDto> ProductTypeLists { get; set; }
        public List<SchoolTypeListDto> SchoolTypeLists { get; set; }
        public List<PropertyTypeListDto> PropertyTypeLists { get; set; }
        public List<ReferenceCheckListDto> ReferenceCheckLists { get; set; }
        public List<SchoolClassListDto> SchoolClassLists { get; set; }
        public List<LoanTenureRequiredListDto> loanTenureRequired { get; set; }
        public List<NatureOfBusinessListDto> NatureOfBusinessLists { get; set; }


        public List<RespondantDesignationListDto> RespondantDesignations { get; set; }
        public List<ApplicantSourceListDto> ApplicantSources { get; set; }
        public List<ReasonForNotBeingInterestedListDto> reasonForNotBeingInteresteds { get; set; }
        public List<AcademicSessionListDto> academicSessions { get; set; }
        public List<OtherSourceOfIncomeListDto> OtherSourceOfIncomes { get; set; }
        public List<BuildingStatusListDto> BuildingStatuses { get; set; }
        public List<SchoolCategoryListDto> schoolCategories { get; set; }
        public List<TDSBusinessNatureListDto> tDSBusinessNatures { get; set; }
        public List<ClientStatusListDto> clientStatuses { get; set; }
        public List<ReasonOfDeclineListDto> reasonOfDeclines { get; set; }
        public List<CreditBureauCheckListDto> creditBureauChecks { get; set; }
        public List<LoanPurposeClassificationListDto> loanPurposeClassifications { get; set; }
        public List<SpouseStatusListDto>  SpouseStatuses{ get; set; }
        public List<RentAgreementSignatoryListDto>  rentAgreementSignatories { get; set; }
        public List<RentAgreementSignatoryOtherListDto>  rentAgreementSignatoryOthers { get; set; }
        public List<BusinessNatureListDto>  businessNatures { get; set; }
        public List<ContactPreferencesListDto>  contactPreferences { get; set; }
        public List<BusinessTypeListDto>  businessTypes { get; set; }
        public List<LegalStatusListDto>  legalStatuses { get; set; }
        public List<SchoolLevelListDto>  schoolLevels { get; set; }
        public List<NumbersListDto>  NumbersLists { get; set; }
        public List<NumbersListDto> PercentageLists { get; set; }
        public List<NumbersListDto> AvgFeeLists { get; set; }
        public List<ClientBusinessClassificationListDto>  clientBusinessClassifications { get; set; }
        public List<RelationshipWithApplicantListDto>  relationshipWithApplicants { get; set; }
        public List<OtherAssociatedIncomeListDto> OtherAssociatedIncomes { get; set; }
        public List<NaSourceOfIncomeListDto> naSourceOfIncomes { get; set; }
        public List<DesignationListDto> Designations { get; set; }
        public List<BankListDto> Banks { get; set; }
        public List<BankListDto> BanksForExposure { get; set; }
        public List<AgeOfVehicleListDto> ageOfVehicles { get; set; }
        public List<BankRatingListDto> BankRatings { get; set; }
        public List<CreditBureauReportedListDto> CreditBureauReporteds { get; set; }
        public List<LoanNatureListDto> loanNatures { get; set; }
        public List<ApplicantTypeListDto>  applicantTypes { get; set; }
        public List<ContactSourceListDto> contactSources { get; set; }
        public List<InventoryEntrySourceListDto> inventoryEntrySources { get; set; }
        public List<InventoryRecordMaintenanceListDto> inventoryRecordMaintenances { get; set; }
        public List<NatureOfEmploymentListDto> NatureOfEmployments { get; set; }
        public List<CompanyTypeListDto> CompanyTypes { get; set; }

        public List<BuildingCondition> BuildingConditionsRep { get; set; }
        public List<PowerBackup> PowerBackupRep { get; set; }
        public List<AyasPresent> AyasPresentRep { get; set; }
        public List<CleanWater> CleanWaterRep { get; set; }
        public List<LearningAid> LearningAidRep { get; set; }
        public List<TeacherTraining> TeacherTrainingRep { get; set; }
        public List<SecurityGuard> SecurityGuardRep { get; set; }
        public List<FinancialRecord> FinancialRecordRep { get; set; }
        public List<BusinessRadius> BusinessRadiusRep { get; set; }
        public List<BankingTransaction> BankingTransactionRep { get; set; }

        public List<PeopleSteal> PeopleStealRep { get; set; }
        public List<AvoidConflict> AvoidConflictRep { get; set; }
        public List<BiggestMotivation> BiggestMotivationRep { get; set; }
        public List<HopefulFuture> HopefulFutureRep { get; set; }
        public List<DigitalInitiative> DigitalInitiativeRep { get; set; }
        public List<TeacherTrainingDay> TeacherTrainingDayRep { get; set; }
        public List<ParentEngagement> ParentEngagementRep { get; set; }
        public List<SpouseFamilyOtherIncome> SpouseFamilyOtherIncomeRep { get; set; }
        public List<OtherPaymentBehaviour> OtherPaymentBehaviourRep { get; set; }
        public List<LiabilityType> LiabilityTypeRep { get; set; }


    }
}
