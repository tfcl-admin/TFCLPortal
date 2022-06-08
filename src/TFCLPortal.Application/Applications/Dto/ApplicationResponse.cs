using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications.Dto
{
   public class ApplicationResponse
    {
        public int ApplicationId { get; set; }
        public string ClientId { get; set; }
        public string CreatedDateTime { get; set; }
        public string Message { get; set; }

        public int fk_ProductId { get; set; }
        public string MinLimitForUnsecuredLoan { get; set; } // in Loan Requision Details
        public string MaxLimitForUnsecuredLoan { get; set; } // in Loan Requision Details
        public string ApplicantMinAge { get; set; }// in Personal Details
        public string ApplicantMaxAge { get; set; }// in Personal Details
        public string BusinessAgeYears { get; set; }// in Business Details
        public string BusinessAgeAtCurrentPlaceYears { get; set; }// in Business Details
        public string MinPercentageOfSAexpAgainstSAincome { get; set; }// in Loan Eligibility
        public string MaxPercentageOfNAItotalSchoolRevenue { get; set; }// in Loan Eligibility
        public string MinPercentageOfHHEtotalSchoolRevenue { get; set; }// in Loan Eligibility
        public string MaxLimitForInstallmentRatio { get; set; }// in Loan Eligibility
        public string GuarantorMinAge { get; set; }// in Guarantor Details
        public string GuarantorMaxAge { get; set; }// in Guarantor Details

        //New Fields Start
        public string LTVForResidentialBuilding { get; set; }
        public string LTVForResidentialLand { get; set; }
        public string LTVForCommercialBuilding { get; set; }
        public string LTVForCommercialLand { get; set; }
        public string LTVForAgriculturalLand { get; set; }
        public string LTVForVehicleLessThanOneYear { get; set; }
        public string LTVForVehicleLessThanFiveYear { get; set; }
        public string LTVForVehicleMoreThanFiveYear { get; set; }
        public string LTVForTDRratedA { get; set; }
        public string LTVForTDRratedB { get; set; }
        public string LTVForFranchiseAgreement { get; set; }
        public string LTVForGold { get; set; }
        public string MinStudentEnrolled { get; set; }

        public ApplicationListDto OldApplication { get; set; }
        //public ApplicationListDto NewApplication { get; set; }
        //New Fields End
    }
    public class CnicCheckResponse
    {
        public int status { get; set; }
        public int previousApplicationId { get; set; }
        public int previousProductType { get; set; }
        public string MessageToShow { get; set; }
    }
}
