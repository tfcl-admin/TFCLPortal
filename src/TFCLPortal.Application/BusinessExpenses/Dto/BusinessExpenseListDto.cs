using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessExpenses.Dto
{
    [AutoMapFrom(typeof(BusinessExpense))]
    public class BusinessExpenseListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public decimal TeacherSalary { get; set; }
        public decimal OtherSalary { get; set; }
        public decimal Rent { get; set; }
        public decimal Utilities { get; set; }
        public decimal Entertainment { get; set; }
        public decimal RepairMaintenance { get; set; }
        public decimal Transportation { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal TotalMonthlyExpneses { get; set; }
        public decimal ProvisisonExpneses { get; set; }
        public decimal NetMonthlyBusinessExpense { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        public List<BusinessExpenseSchoolListDto> businessExpenseSchool { get; set; }

        //NEW
        public string nGrandTotalBusinessExpense { get; set; }
        public string nPercentageOfBeAgaintNETbI { get; set; }
        public string nMinConsideredPercentage { get; set; }
        public string nConsideredBusinessExpense { get; set; }

    }
}
