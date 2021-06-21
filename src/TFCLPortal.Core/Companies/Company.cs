using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Branches;

namespace TFCLPortal.Companies
{
    [Table("Company")]
    public  class Company : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal GST { get; set; }
        public string NTN { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Active { get; set; }

        public List<Branch> BranchDetails{ get; set; }


    }
}
