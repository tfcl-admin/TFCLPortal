using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes
{
    public interface IOtherAssociatedIncomeAppService
    {
        Task<ListResultDto<OtherAssociatedIncomeListDto>> GetAllOtherAssociatedIncomes();
        List<OtherAssociatedIncomeListDto> GetAllList();
    }
}
