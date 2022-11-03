using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ClosingMonths.Dto;

namespace TFCLPortal.ClosingMonths
{
    public interface IClosingMonthAppService : IApplicationService
    {
        ClosingMonthListDto GetClosingMonthByBranchId(int Id);
        List<ClosingMonthListDto> GetAllClosingMonths();
        Task<string> CreateClosingMonth(CreateClosingMonthDto input);
        string updateClosingMonth(int Id, int BranchId);
        bool checkIfOpen(int BranchId,int CurrMonth,int CurrYear);
    }
}
