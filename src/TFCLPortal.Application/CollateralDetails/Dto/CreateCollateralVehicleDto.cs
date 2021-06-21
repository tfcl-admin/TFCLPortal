using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CollateralVehicles;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapTo(typeof(CollateralVehicle))]
    public class CreateCollateralVehicleDto
    {
        public int Fk_ColateralID { get; set; }
        public int CollateralOwnership { get; set; }
        public string RegistrationNo { get; set; }
        public string MAKE { get; set; }
        public string ModelNo { get; set; }
        public int? VehicleAge { get; set; }
        public string VehicleAgeName { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string HorsePowerCC { get; set; }
        public string MarketValue { get; set; }

        //New
        public DateTime? DateOfEvaluation { get; set; }
        public string VehicleOwnerName { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsurancePolicyNo { get; set; }
        public string InsuredValue { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public string EvaluatorName { get; set; }
        public string EvaluatorContactNumber { get; set; }
        public string EvaluatorBusinessName { get; set; }
        public string RelationWithApplicant { get; set; }

        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }

    }
}
