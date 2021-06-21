using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.HouseholdIncomesExpenses.Dto;

namespace TFCLPortal.HouseholdIncomesExpenses
{
    public interface IHouseholdIncomeAppService : IApplicationService
    {
        Task<HouseholdIncomeParentListDto> GetHouseholdIncomeById(int Id);
        string CreateHouseholdIncome(CreateHouseholdIncomeParentDto input);
        Task<string> UpdateHouseholdIncome(UpdateHouseholdIncomeParentDto input);
        HouseholdIncomeParentListDto GetHouseholdIncomeByApplicationId(int ApplicationId);
        bool CheckHouseholdIncomeByApplicationId(int ApplicationId);
    }
}
