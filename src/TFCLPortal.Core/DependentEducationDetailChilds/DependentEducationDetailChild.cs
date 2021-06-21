using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DependentEducationDetails
{
    [Table("DependentEducationDetailChild")]
    public class DependentEducationDetailChild : FullAuditedEntity<int>
    {
        public int FK_DependentEducationId{ get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int Gender { get; set; }
        public string dependentClass { get; set; }
        public string EiName { get; set; }
        public string MonthlyFee { get; set; }
        public int PaymentFrequency { get; set; }
    }
}
