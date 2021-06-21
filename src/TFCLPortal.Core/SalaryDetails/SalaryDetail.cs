using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.SalaryDetails
{
    [Table("SalaryDetail")]
    public class SalaryDetail : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalary { get; set; }
    }
}
