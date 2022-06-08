using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.SchoolNonFinancials.Dto;

namespace TFCLPortal.SchoolNonFinancials
{
    public interface ISchoolNonFinancialAppService : IApplicationService
    {
        Task<string> CreateSchoolNonFinancial (CreateSchoolNonFinancialDto Input);
        Task<SchoolNonFinancialListDto> GetSchoolNonFinancialByApplicationId(int ApplicationId);
        bool CheckSchoolNonFinancialByApplicationId(int ApplicationId);
    }
}
