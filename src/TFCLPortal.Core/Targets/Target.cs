using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Targets
{
    [Table("Target")]
    public class Target : FullAuditedEntity<int>
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
