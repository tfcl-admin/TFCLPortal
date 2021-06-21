using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TDSBusinessExpenses.Dto;

namespace TFCLPortal.TDSBusinessExpenses
{
    public interface ITDSBusinessExpenseAppService : IApplicationService
    {
        Task<TDSBusinessExpenseListDto> GetTDSBusinessExpenseById(int Id);
        Task CreateTDSBusinessExpense(CreateTDSBusinessExpenseDto input);
        Task<string> UpdateTDSBusinessExpense(UpdateTDSBusinessExpenseDto input);
        Task<TDSBusinessExpenseListDto> GetTDSBusinessExpenseByApplicationId(int ApplicationId);
        bool CheckTDSBusinessExpenseByApplicationId(int ApplicationId);
    }
}
