using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessIncomes
{
    [Table("BusinessIncome")]
    public class BusinessIncome : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }       
        public string TotalFeeCollection { get; set; }
        public string AnyOtherIncome { get; set; }
        public string GrandTotalIncome { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string OtherSourceOfFund { get; set; }
        public string nGrandTotalSchoolStudents { get; set; }
        public string nGrandTotalAcademyStudents { get; set; }
        public string nGrandTotalSchoolFeeIncome { get; set; }
        public string nGrandTotalAcademyFeeIncome { get; set; }
    }
}
