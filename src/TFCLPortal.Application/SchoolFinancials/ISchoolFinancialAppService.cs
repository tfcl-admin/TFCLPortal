using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.SchoolFinancials.Dto;

namespace TFCLPortal.SchoolFinancials
{
    public interface ISchoolFinancialAppService : IApplicationService
    {
        Task<string> CreateSchoolFinancial (CreateSchoolFinancialDto Input);
        Task<SchoolFinancialListDto> GetSchoolFinancialByApplicationId(int ApplicationId);
        bool CheckSchoolFinancialByApplicationId(int ApplicationId);
    }
}
