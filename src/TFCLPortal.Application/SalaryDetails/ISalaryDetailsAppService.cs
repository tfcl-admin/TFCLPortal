using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.SalaryDetails.Dto;

namespace TFCLPortal.SalaryDetails
{
    public interface ISalaryDetailsAppService :IApplicationService
    {
        Task<SalaryDetailDto> GetSalaryDetailById(int Id);
        Task CreateSalaryDetail(CreateSalaryDetailDto input);
        Task<string> UpdateSalaryDetail(UpdateSalaryDetailDto input);
        Task<SalaryDetailDto> GetSalaryDetailByApplicationId(int ApplicationId);
        bool CheckSalaryDetailByApplicationId(int ApplicationId);
    }
}
