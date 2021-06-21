using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AssociatedIncomeDetails.Dto;

namespace TFCLPortal.AssociatedIncomeDetails
{
    public interface IAssociatedIncomeAppService : IApplicationService
    {
        Task<string> CreateAssociatedIncomeDetails(CreateAssociatedIncomeDto input);
        AssociatedIncomeListDto GetAssociatedIncomeDetailByApplicationId(int Id);
        bool CheckAssociatedIncomeDetailByApplicationId(int Id);


    }
}
