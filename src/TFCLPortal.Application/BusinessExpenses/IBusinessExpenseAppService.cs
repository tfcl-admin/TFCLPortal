using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessExpenses.Dto;

namespace TFCLPortal.BusinessExpenses
{
    public interface IBusinessExpenseAppService : IApplicationService
    {
        Task<BusinessExpenseListDto> GetBusinessExpenseById(int Id);
        Task CreateBusinessExpense(CreateBusinessExpenseDto input);
        Task<string> UpdateBusinessExpense(UpdateBusinessExpenseDto input);
        Task<BusinessExpenseListDto> GetBusinessExpenseByApplicationId(int ApplicationId);
        bool CheckBusinessExpenseByApplicationId(int ApplicationId);
    }
}
