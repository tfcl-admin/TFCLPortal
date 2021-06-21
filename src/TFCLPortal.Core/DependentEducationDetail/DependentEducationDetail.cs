using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DependentEducationDetails
{
    [Table("DependentEducationDetail")]
    public class DependentEducationDetail : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public bool? isDependentEducation { get; set; }
        public string TotalMonthlyFee { get; set; }
    }
}
