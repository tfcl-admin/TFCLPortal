using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Targets.Dto
{
    [AutoMapTo(typeof(Target))]
    public class CreateTargetDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_SdeId { get; set; }
        public int Fk_BranchId { get; set; }
        public int Fk_ProductTypeId { get; set; }
        public int NoOfApplications { get; set; }
        public int DisbursmentValue { get; set; }
        public decimal Yeild { get; set; }
        public decimal SecuredUnsecuredRatio { get; set; }
        public int RepeatClients { get; set; }
        public int Maturity { get; set; }
    }
}
