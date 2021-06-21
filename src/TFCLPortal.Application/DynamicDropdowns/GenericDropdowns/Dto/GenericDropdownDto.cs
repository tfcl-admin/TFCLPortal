using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.CompanyTypes;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;

namespace TFCLPortal.DynamicDropdowns.GenericDropdowns.Dto
{
    public class GenericDropdownDto
    {
        public List<LoanPurposeListDto> loanPurposeLists { get; set; }
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

    }
}
