using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.EmploymentDetails.Dto;

namespace TFCLPortal.EmploymentDetails
{
   public interface IEmploymentDetailAppService: IApplicationService
    {

        Task<string> Create(CreateEmploymentDetailInput createEmploymentDetailInput, int applicationId);
        Task<string> Update(UpdateEmploymentDtoList editEmploymentDetailinput);
        Task<List<EmploymentDetailListDto>> GetEmploymentDetailById(int Id);
        Task<List<EmploymentDetailListDto>> GetEmploymentDetailByApplicationId(int ApplicationId);
        bool CheckEmploymentDetailByApplicationId(int ApplicationId);
    }
}
