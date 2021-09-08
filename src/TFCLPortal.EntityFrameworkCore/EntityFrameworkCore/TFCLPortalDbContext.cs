using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TFCLPortal.Authorization.Roles;
using TFCLPortal.Authorization.Users;
using TFCLPortal.MultiTenancy;
using TFCLPortal.DynamicDropdowns.Qualifications;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.StudentsGender;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.CollateralOwnerships;
using TFCLPortal.DynamicDropdowns.CollateralTypes;
using TFCLPortal.DynamicDropdowns.LandTypes;
using TFCLPortal.DynamicDropdowns.CreditCommettees;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;
using TFCLPortal.DynamicDropdowns.Genders;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.PersonalDetails;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.DynamicDropdowns.SchoolClasses;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.OtherDetails;
using TFCLPortal.BusinessPlans;
using TFCLPortal.ExposureDetails;
using TFCLPortal.ContactDetails;
using TFCLPortal.CollateralDetails;
using TFCLPortal.HouseholdIncomesExpenses;
using TFCLPortal.BusinessIncomes;
using TFCLPortal.ExposureDetailChilds;
using TFCLPortal.BusinessExpenses;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.BusinessIncomeSchools;
using TFCLPortal.BusinessDetails;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.CollateralLandBuildings;
using TFCLPortal.CollateralVehicles;
using TFCLPortal.CollateralTDRs;
using TFCLPortal.ColatteralGolds;
using TFCLPortal.Applications;
using TFCLPortal.DynamicDropdowns.SchoolTypes;
using TFCLPortal.AppScreenStatuses;
using TFCLPortal.DynamicDropdowns.PropertyTypes;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.FilesUploads;
using TFCLPortal.Mobilizations;
using TFCLPortal.DynamicDropdowns.RespondantDesignations;
using TFCLPortal.Companies;
using TFCLPortal.Branches;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.WorkFlows;
using TFCLPortal.LoanAmortizations;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.ProductMarkupRates;
using TFCLPortal.DescripentScreens;
using TFCLPortal.TaleemSchoolAsasahs;
using TFCLPortal.TaleemSchoolSarmayas;
using TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS;
using TFCLPortal.DynamicDropdowns.NatureOfBusinesses;
using TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS;
using TFCLPortal.Migrations;
using TFCLPortal.DynamicDropdowns.ApplicantSources;
using TFCLPortal.DynamicDropdowns.ReasonForNotBeingInteresteds;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes;
using TFCLPortal.DynamicDropdowns.BuildingStatuses;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.MobilizationsLogs;
using TFCLPortal.TDSBusinessNatures;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.SpouseStatuses;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatoryOthers;
using TFCLPortal.BusinessNatures;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.DynamicDropdowns.SchoolLevels;
using TFCLPortal.DynamicDropdowns.LegalStatuses;
using TFCLPortal.DynamicDropdowns.ContactPreferences;
using TFCLPortal.DynamicDropdowns.ClientBusinessClassifications;
using TFCLPortal.CollateralFranchises;
using TFCLPortal.ApiCallLogs;
using TFCLPortal.BusinessIncomeSchoolClasses;
using TFCLPortal.BusinessIncomeSchoolAcademies;
using TFCLPortal.BusinessIncomeAcademyClasses;
using TFCLPortal.DynamicDropdowns.RelationshipWithApplicants;
using TFCLPortal.BankAccountChildDetails;
using TFCLPortal.DynamicDropdowns.DropdownUpdateStatuses;
using TFCLPortal.AssociatedIncomes;
using TFCLPortal.NonAssociatedIncomes;
using TFCLPortal.AssociatedIncomeChilds;
using TFCLPortal.NonAssociatedIncomeChilds;
using TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes;
using TFCLPortal.DynamicDropdowns.NaSourceOfIncomes;
using TFCLPortal.AssociatedIncomeGrandChilds;
using TFCLPortal.BusinessExpenseSchoolAcademyClasses;
using TFCLPortal.BusinessExpenseSchools;
using TFCLPortal.BusinessExpenseSchoolClasses;
using TFCLPortal.BusinessExpenseSchoolAcademies;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.ApplicantTypes;
using TFCLPortal.DynamicDropdowns.ContactSources;
using TFCLPortal.FileTypes;
using TFCLPortal.HouseholdIncomeExpenseParents;
using TFCLPortal.Banks;
using TFCLPortal.DynamicDropdowns.CreditBureauReporteds;
using TFCLPortal.DeviationMatrices;
using TFCLPortal.ApplicationWiseDeviationVariables;
using TFCLPortal.DeviationApprovals;
using TFCLPortal.DynamicDropdowns.AgeOfVehicles;
using TFCLPortal.DynamicDropdowns.BankRatings;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.DynamicDropdowns.LoanNatures;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.BccDecisions;
using TFCLPortal.McrcDecisions;
using TFCLPortal.McrcRecords;
using TFCLPortal.McrcStates;
using TFCLPortal.Schedules;
using TFCLPortal.LoanSchedules;
using TFCLPortal.FcmTokens;
using TFCLPortal.NotificationLogs;
using TFCLPortal.ScheduleTemps;
using TFCLPortal.ScheduleInstallmentTemps;
using TFCLPortal.TaleemDostSahulats;
using TFCLPortal.TaleemJariSahulats;
using TFCLPortal.TaleemTeacherSahulats;
using TFCLPortal.InstallmentPayments;
using TFCLPortal.CompanyBankAccounts;
using TFCLPortal.DependentEducationDetails;
using TFCLPortal.NatureOfPayments;
using TFCLPortal.BusinessDetailsTDS;
using TFCLPortal.TdsInventoryDetails;
using TFCLPortal.TdsInventoryDetailChilds;
using TFCLPortal.TdsInventoryDetailGrandChilds;
using TFCLPortal.DynamicDropdowns.InventoryEntrySources;
using TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;
using TFCLPortal.DynamicDropdowns.CompanyTypes;
using TFCLPortal.EarlySettlements;
using TFCLPortal.SalesDetails;
using TFCLPortal.Holidays;
using TFCLPortal.PurchaseDetails;
using TFCLPortal.AuthorizeInstallmentPayments;
using TFCLPortal.TDSBusinessExpenses;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.TJSLoanEligibilities;
using TFCLPortal.WriteOffs;
using TFCLPortal.DeceasedSettlements;
using TFCLPortal.EmploymentDetails;
using TFCLPortal.ManagmentCommitteeDecisions;
using TFCLPortal.SalaryDetails;
using TFCLPortal.TaggedPortfolios;
using TFCLPortal.Targets;

namespace TFCLPortal.EntityFrameworkCore
{
    public class TFCLPortalDbContext : AbpZeroDbContext<Tenant, Role, User, TFCLPortalDbContext>
    {
        /* Dropdowns DBSets */
        public DbSet<Qualification> People { get; set; }
        public DbSet<DynamicDropdowns.Ownership.OwnershipStatus> OwnershipStatus { get; set; }
        public DbSet<StudentGender> StudentGenderDbSet { get; set; }
        public DbSet<Occupation> OccupationDbSet { get; set; }
        public DbSet<FundSource> FundSourceDbSet { get; set; }
        public DbSet<CollateralOwnership> CollateralOwnershipDbSet { get; set; }
        public DbSet<CollateralType> CollateralTypeDbSet { get; set; }
        public DbSet<LandType> LandTypeDbSet { get; set; }
        public DbSet<CreditCommettee> CreditCommetteeDbSet { get; set; }
        public DbSet<ApplicantReputation> ApplicantReputationDbSet { get; set; }
        public DbSet<UtilityBillPayment> UtilityBillPaymentDbSet { get; set; }
        public DbSet<BusinessLegalStatus> BusinessLegalStatusDbSet { get; set; }
        public DbSet<Gender> GenderDbSet { get; set; }
        public DbSet<MaritalStatus> MaritalStatusDbSet { get; set; }
        public DbSet<WriteOff> WriteOffDbSet { get; set; }
        public DbSet<MobilizationStatus> MobilizationStatusDbSet { get; set; }
        public DbSet<DeviationMatrix> DeviationMatrixDbSet { get; set; }
        public DbSet<FinalWorkflow> FinalWorkflowDbSet { get; set; }
        public DbSet<DeviationApproval> DeviationApprovalDbSet { get; set; }
        public DbSet<BranchManagerAction> BranchManagerActionDbSet { get; set; }
        public DbSet<TJSLoanEligibility> TJSLoanEligibilityDbSet { get; set; }
        public DbSet<DeceasedSettlement> DeceasedSettlementDbSet { get; set; }
        public DbSet<ManagmentCommitteeDecision> ManagmentCommitteeDecisionDbSet { get; set; }
        public DbSet<LoanNature> LoanNatureDbSet { get; set; }
        public DbSet<BccDecision> BccDecisionDbSet { get; set; }
        public DbSet<EmploymentDetail> EmploymentDetailDbSet { get; set; }
        public DbSet<McrcDecision> McrcDecisionDbSet { get; set; }
        public DbSet<ApplicationWiseDeviationVariable> ApplicationWiseDeviationVariableDbSet { get; set; }

        //NEW DROPDOWN API ADDITION START
        public DbSet<RespondantDesignation> RespondantDesignationDbSet { get; set; }
        public DbSet<ApplicantSource> ApplicantSourceDbSet { get; set; }
        public DbSet<ReasonForNotBeingInterested> ReasonForNotBeingInterestedDbSet { get; set; }
        public DbSet<AcademicSession> AcademicSessionDbSet { get; set; }
        public DbSet<OtherSourceOfIncome> OtherSourceOfIncomeDbSet { get; set; }
        public DbSet<BuildingStatus> BuildingStatusDbSet { get; set; }
        public DbSet<SchoolCategory> SchoolCategoryDbSet { get; set; }
        public DbSet<SalaryDetail> SalaryDetailDbSet { get; set; }
        public DbSet<SalaryDetailChild> SalaryDetailChildDbSet { get; set; }
        public DbSet<LoanSchedule> LoanScheduleDbSet { get; set; }
        public DbSet<McrcRecord> McrcRecordDbSet { get; set; }
        public DbSet<McrcState> McrcStateDbSet { get; set; }
        public DbSet<NatureOfEmployment> NatureOfEmploymentDbSet { get; set; }
        public DbSet<CompanyType> CompanyTypeDbSet { get; set; }
        //NEW DROPDOWN API ADDITION END

        public DbSet<TaggedPortfolio> TaggedPortfolioDbSet { get; set; }
        public DbSet<CompanyBankAccount> CompanyBankAccountDbSet { get; set; }
        public DbSet<ProductType> ProductTypeDbSet { get; set; }
        public DbSet<SchoolClass> SchoolClassDbSet { get; set; }
        public DbSet<Province> ProvinceDbSet { get; set; }
        public DbSet<District> DistrictDbSet { get; set; }
        public DbSet<FileType> FileTypeDbSet { get; set; }
        public DbSet<SchoolType> SchoolTypeDbSet { get; set; }
        public DbSet<Holiday> HolidayDbSet { get; set; }
        public DbSet<PropertyType> PropertyTypeDbSet { get; set; }
        public DbSet<InstallmentPayment> InstallmentPaymentDbSet { get; set; }
        public DbSet<AuthorizeInstallmentPayment> AuthorizeInstallmentPaymentDbSet { get; set; }
        public DbSet<EarlySettlement> EarlySettlementDbSet { get; set; }
        public DbSet<ApiCallLog> ApiCallLogDbSet { get; set; }
        public DbSet<RelationshipWithApplicant> RelationshipWithApplicantDbSet { get; set; }

        /* Screens DBSet*/
        public DbSet<ReferenceCheck> ReferenceCheckDbSet { get; set; }
        public DbSet<AgeOfVehicle> AgeOfVehicleDbSet { get; set; }
        public DbSet<Schedule> ScheduleDbSet { get; set; }
        public DbSet<ScheduleTemp> ScheduleTempDbSet { get; set; }
        public DbSet<ScheduleInstallmentTemp> ScheduleInstallmentTempDbSet { get; set; }
        public DbSet<ScheduleInstallment> ScheduleInstallmentDbSet { get; set; }
        public DbSet<BankRating> BankRatingDbSet { get; set; }
        public DbSet<PaymentFrequency> PaymentFrequencyDbSet { get; set; }
        public DbSet<LoanPurpose> LoanPurposeDbSet { get; set; }
        public DbSet<PersonalDetail> PersonalDetailDbSet { get; set; }
        public DbSet<Target> TargetDbSet { get; set; }
        public DbSet<Preferences.Preference> PreferenceDbSet { get; set; }
        public DbSet<CoApplicantDetails.CoApplicantDetail> CoApplicantDetailDbSet { get; set; }
        public DbSet<GuarantorDetails.GuarantorDetail> GuarantorDetailDbSet { get; set; }
        public DbSet<ForSDES.ForSDE> ForSDEDbSet { get; set; }
        public DbSet<BusinessDetails.BusinessDetail> BusinessDetails { get; set; }
        public DbSet<School_Branch> school_Branches { get; set; }
        public DbSet<OtherDetail> OtherDetailDbSet { get; set; }
        public DbSet<BusinessPlan> BusinessPlanDbSet { get; set; }
        public DbSet<ExposureDetail> ExposureDetailDbSet { get; set; }
        public DbSet<ExposureDetailChild> ExposureDetailChildDbSet { get; set; }
        public DbSet<ContactDetail> ContactDetailDbSet { get; set; }
        public DbSet<CollateralDetail> CollateralDetailDbSet { get; set; }
        public DbSet<HouseholdIncomeExpense> HouseholdIncomeExpenseDbSet { get; set; }
        public DbSet<HouseholdIncomeExpenseParent> HouseholdIncomeExpenseParentDbSet { get; set; }
        public DbSet<BusinessExpense> BusinessExpenseDbSet { get; set; }
        public DbSet<BusinessExpenseSchool> BusinessExpenseSchoolDbSet { get; set; }
        public DbSet<BusinessExpenseSchoolClass> BusinessExpenseSchoolClassDbSet { get; set; }
        public DbSet<BusinessExpenseSchoolAcademy> BusinessExpenseSchoolAcademyDbSet { get; set; }
        public DbSet<BusinessExpenseSchoolAcademyClass> BusinessExpenseSchoolAcademyClassDbSet { get; set; }

        public DbSet<AssociatedIncome> AssociatedIncomeDbSet { get; set; }
        public DbSet<AssociatedIncomeChild> AssociatedIncomeChildDbSet { get; set; }
        public DbSet<AssociatedIncomeGrandChild> AssociatedIncomeGrandChildDbSet { get; set; }

        public DbSet<SalesDetail> SalesDetailDbSet { get; set; }
        public DbSet<SalesDetailChild> SalesDetailChildDbSet { get; set; }
        public DbSet<SalesDetailGrandChild> SalesDetailGrandChildDbSet { get; set; }

        public DbSet<PurchaseDetail> PurchaseDetailDbSet { get; set; }
        public DbSet<PurchaseDetailChild> PurchaseDetailChildDbSet { get; set; }
        public DbSet<PurchaseDetailGrandChild> PurchaseDetailGrandChildDbSet { get; set; }

        public DbSet<TdsInventoryDetail> TdsInventoryDetailDbSet { get; set; }
        public DbSet<TdsInventoryDetailChild> TdsInventoryDetailChildDbSet { get; set; }
        public DbSet<TdsInventoryDetailGrandChild> TdsInventoryDetailGrandChildDbSet { get; set; }

        public DbSet<TDSBusinessExpense> TDSBusinessExpenseDbSet { get; set; }
        public DbSet<TDSBusinessExpenseChild> TDSBusinessExpenseChildDbSet { get; set; }
        public DbSet<TDSBusinessExpenseGrandChild> TDSBusinessExpenseGrandChildDbSet { get; set; }

        public DbSet<NonAssociatedIncome> NonAssociatedIncomeDbSet { get; set; }
        public DbSet<NonAssociatedIncomeChild> NonAssociatedIncomeChildDbSet { get; set; }
        public DbSet<AssetLiabilityDetail> AssetLiabilityDetailDbSet { get; set; }
        public DbSet<BusinessIncome> BusinessIncomeDbSet { get; set; }
        public DbSet<BusinessIncomeSchool> BusinessIncomeSchoolDbSet { get; set; }
        public DbSet<Designation> DesignationDbSet { get; set; }
        public DbSet<BusinessIncomeSchoolClass> BusinessIncomeSchoolClassDbSet { get; set; }
        public DbSet<BusinessIncomeSchoolAcademy> BusinessIncomeSchoolAcademyDbSet { get; set; }
        public DbSet<BusinessIncomeSchoolAcademyClass> BusinessIncomeSchoolAcademyClassDbSet { get; set; }
        public DbSet<CollateralLandBuilding> CollateralLandBuildingDbSet { get; set; }
        public DbSet<CollateralVehicle> CollateralVehicleDbSet { get; set; }
        public DbSet<CollateralTDR> CollateralTDRDbSet { get; set; }
        public DbSet<NatureOfPayment> NatureOfPaymentDbSet { get; set; }
        public DbSet<CollateralGold> CollateralGoldDbSet { get; set; }
        public DbSet<CollateralFranchise> CollateralFranchiseDbSet { get; set; }
        public DbSet<Applications.Applicationz> ApplicationsDbSet { get; set; }
        public DbSet<AppScreenStatus> AppScreenStatusDbSet { get; set; }
        public DbSet<BankAccountDetail> BankAccountDetailDbSet { get; set; }
        public DbSet<DropdownUpdateStatus> DropdownUpdateStatusDbSet { get; set; }
        public DbSet<BankAccountChildDetail> BankAccountChildDetailDbSet { get; set; }
        public DbSet<FilesUpload> FilesUploadDbSet { get; set; }
        public DbSet<Mobilization> MobilizationDbSet { get; set; }
        public DbSet<MobilizationsLog> MobilizationLogDbSet { get; set; }
        public DbSet<TDSBusinessNature> TdsBusinessNatureDbSet { get; set; }
        public DbSet<Company> CompanyDbSet { get; set; }
        public DbSet<Branch> BranchDbSet { get; set; }
        public DbSet<ApplicationDescripantDeclineState> ApplicationDescripantDeclineStateDbSet { get; set; }
        public DbSet<BADataCheck> BADataCheckDbSet { get; set; }
        public DbSet<BccState> BccStateDbSet { get; set; }
        public DbSet<BranchCreditCommittee> BranchCreditCommitteeDbSet { get; set; }
        public DbSet<WorkFlow> WorkFlowDbSet { get; set; }
        public DbSet<WorkFlowApplicationState> WorkFlowApplicationStateDbSet { get; set; }
        public DbSet<LoanTenureRequired> LoanTenureRequiredDbSet { get; set; }
        public DbSet<LoanAmortizations.LoanAmortization> LoanAmortizationDbSet { get; set; }
        public DbSet<LoanAmortizationChild> LoanAmortizationChildDbSet { get; set; }
        public DbSet<LoanEligibility> LoanEligibilityDbSet { get; set; }
        public DbSet<ProductDetail> ProductDetailDbSet { get; set; }
        public DbSet<Product> ProductDbSet { get; set; }
        public DbSet<DescripentScreen> DescripentScreenDbSet { get; set; }
        public DbSet<TaleemSchoolAsasah> TaleemSchoolAsasahDbSet { get; set; }
        public DbSet<TaleemSchoolSarmaya> TaleemSchoolSarmayaDbSet { get; set; }
        public DbSet<TaleemDostSahulat> TaleemDostSahulatDbSet { get; set; }
        public DbSet<TaleemJariSahulat> TaleemJariSahulatDbSet { get; set; }
        public DbSet<TaleemTeacherSahulat> TaleemTeacherSahulatDbSet { get; set; }
        public DbSet<DependentEducationDetail> DependentEducationDetailDbSet { get; set; }
        public DbSet<DependentEducationDetailChild> DependentEducationDetailChildDbSet { get; set; }
        public DbSet<InventoryEntrySource> InventoryEntrySourceDbSet { get; set; }
        public DbSet<InventoryRecordMaintenance> InventoryRecordMaintenanceDbSet { get; set; }


        public DbSet<BusinessNature> BusinessNatureDbSet { get; set; }
        public DbSet<ApplicantType> ApplicantTypeDbSet { get; set; }
        public DbSet<ContactSource> ContactSourceDbSet { get; set; }
        public DbSet<NaSourceOfIncome> NaSourceOfIncomeDbSet { get; set; }
        public DbSet<ContactPreference> ContactPreferenceDbSet { get; set; }
        public DbSet<BusinessType> BusinessTypeDbSet { get; set; }
        public DbSet<SchoolLevel> SchoolLevelDbSet { get; set; }
        public DbSet<LegalStatus> LegalStatusDbSet { get; set; }
        public DbSet<OtherAssociatedIncome> OtherAssociatedIncomeDbSet { get; set; }
        public DbSet<CreditBureauReported> CreditBureauReportedDbSet { get; set; }
        public DbSet<ClientBusinessClassification> ClientBusinessClassificationDbSet { get; set; }
        public DbSet<FcmToken> FcmTokenDbSet { get; set; }
        public DbSet<NotificationLog> NotificationLogDbSet { get; set; }



        /*Taleem dost Sahulat DBSets*/
        public DbSet<BusinessDetailTDS> BusinessDetailTDSDbSet { get; set; }
        public DbSet<TDSLoanEligibility> TDSLoanEligibilityDbSet { get; set; }
        public DbSet<Bank> BankDbSet { get; set; }
        public DbSet<FinancialInformationTDS> FinancialInformationTDSDbSet { get; set; }
        public DbSet<SalesPurchaseTDS> SalesPurchaseTDSDbSet { get; set; }
        public DbSet<NatureOfBusiness> NatureOfBusinessDbSet { get; set; }
        public DbSet<ClientStatus> ClientStatusesDbSet { get; set; }
        public DbSet<ReasonOfDecline> ReasonOfDeclinesDbSet { get; set; }
        public DbSet<LoanPurposeClassification> LoanPurposeClassificationsDbSet { get; set; }
        public DbSet<CreditBureauCheck> CreditBureauChecksDbSet { get; set; }
        public DbSet<SpouseStatus> SpouseStatusesDbSet { get; set; }
        public DbSet<RentAgreementSignatory> RentAgreementSignatoryDbSet { get; set; }
        public DbSet<RentAgreementSignatoryOther> RentAgreementSignatoryOtherDbSet { get; set; }

        public TFCLPortalDbContext(DbContextOptions<TFCLPortalDbContext> options)
            : base(options)
        {
        }
    }


}
