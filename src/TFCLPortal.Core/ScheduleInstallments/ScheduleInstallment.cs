using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Schedules
{
    [Table("ScheduleInstallment")]
    public class ScheduleInstallment : FullAuditedEntity<Int32>
    {
       
        public int FK_ScheduleId { get; set; }
        public string InstNumber { get; set; }
        public string BalInst { get; set; }
        public string InstallmentDueDate { get; set; }
        public string OsPrincipal_op { get; set; }
        public string AdditionalTranche { get; set; }
        public string OsPrincipal_Opening { get; set; }
        public string markup { get; set; }
        public string principal { get; set; }
        public string installmentAmount { get; set; }
        public string OsPrincipal_Closing { get; set; }
        public bool? isPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool isMarkupPaid { get; set; }
        public bool isPrincipalPaid { get; set; }
    }
}
