using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.HouseholdIncomeExpenseParents;

namespace TFCLPortal.HouseholdIncomesExpenses.Dto
{
    [AutoMapFrom(typeof(HouseholdIncomeExpenseParent))]
    public class HouseholdIncomeParentListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string totalHouseHoldIncomeExpense { get; set; }
        public List<HouseholdIncomeListDto> CreateHouseholdIncomes { get; set; }
    }
}
