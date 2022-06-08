using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SchoolFinancials.Dto
{
    [AutoMapTo(typeof(SchoolFinancial))]
    public class CreateSchoolFinancialDto
    {
        public int ApplicationId { get; set; }
        public string PreviousYear { get; set; }
        public int NoOfClassrooms { get; set; }
        public int NoOfStudents { get; set; }
        public int NoOfTeachingStaff { get; set; }
        public int NoOfNonTeachingStaff { get; set; }
        public string AvgMonthlyFee { get; set; }
        public string TotalRevenue { get; set; }
        public string TotalExpensesFromSalary { get; set; }
        public string TotalExpensesFromRentMortgage { get; set; }
        public string TotalExpensesFromDebt { get; set; }
        public string AllOtherExpenses { get; set; }
        public string TotalProfit { get; set; }
        public string ProfitMargin { get; set; }
        public int spouseFamilyOtherIncome { get; set; }    
        public string TotalAsset { get; set; }
        public string CurrentAsset { get; set; }
        public string TotalLiabilities { get; set; }
        public string CurrentLiabilities { get; set; }
        public string WorkingCapital { get; set; }
    }
}
