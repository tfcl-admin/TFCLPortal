using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Companies;

namespace TFCLPortal.Branches
{
    [Table("Branch")]
    public  class Branch : FullAuditedEntity<int>
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public string Active { get; set; }
        public string Address { get; set; }
        public int FK_companyid { get; set; }
        public int FK_BMid { get; set; }

        [ForeignKey("FK_companyid")]
        public Company Comapny { get; set; }
    }
}
