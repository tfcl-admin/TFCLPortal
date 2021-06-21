using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.HouseholdIncomeExpenseParents;

namespace TFCLPortal.HouseholdIncomesExpenses.Dto
{
    [AutoMapTo(typeof(HouseholdIncomeExpenseParent))]
    public class CreateHouseholdIncomeParentDto
    {
        public int ApplicationId { get; set; }
        public string totalHouseHoldIncomeExpense { get; set; }
        public List<CreateHouseholdIncomeDto> CreateHouseholdIncomes { get; set; }
    }
}
