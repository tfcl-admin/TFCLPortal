using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessIncomes.Dto;

namespace TFCLPortal.BusinessIncomes
{
    public interface IBusinessIncomeAppService : IApplicationService
    {
        Task<BusinessIncomeListDto> GetBusinessIncomeById(int Id);
        Task CreateBusinessIncome(CreateBusinessIncomeDto input);
        Task<string> UpdateBusinessIncome(UpdateBusinessIncomeDto input);
        BusinessIncomeListDto GetBusinessIncomeByApplicationId(int ApplicationId);
        bool CheckBusinessIncomeByApplicationId(int ApplicationId);
    }
}
