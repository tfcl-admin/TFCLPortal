using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.GuarantorDetails
{
    [Table("GuarantorDetails")]
    public class GuarantorDetail : FullAuditedEntity<int>
    {
        public string FullName { get; set; }
        public string SDW { get; set; }
        public string CNICNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PresentAddress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public string UCNumber { get; set; }
        public string MouzaOrTown { get; set; }
        public string RealtionshipWithApplicant { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string Profession { get; set; }
        public string EmployerName { get; set; }
        public string IncomeAvailableForInstallment { get; set; }
        public string MonthlyIncome { get; set; }

        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        //New

        public DateTime? CnicExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Age { get; set; }
        public bool? CreditBureauCheck { get; set; }
        public int? CreditBureauStatus { get; set; }

        public bool? AmlCftCheck { get; set; }
        public bool? AmlCftClearance { get; set; }
        public bool? guaranteedLoanFI { get; set; }
        public string guaranteedAmount { get; set; }
    }
}
