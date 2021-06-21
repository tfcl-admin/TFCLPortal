using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.NonAssociatedIncomeDetails.Dto;

namespace TFCLPortal.NonAssociatedIncomeDetails
{
    public interface INonAssociatedIncomeAppService : IApplicationService
    {
        Task<string> CreateNonAssociatedIncomeDetails(CreateNonAssociatedIncomeDto input);
        NonAssociatedIncomeListDto GetNonAssociatedIncomeDetailByApplicationId(int Id);
        bool CheckNonAssociatedIncomeDetailByApplicationId(int Id);

    }
}
