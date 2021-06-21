using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DependentEducationDetails.Dto;

namespace TFCLPortal.DependentEducationDetails
{
    public interface IDependentEducationDetailsAppService :IApplicationService
    {
        Task<DependentEducationDetailListDto> GetDependentEducationDetailById(int Id);

        Task<List<DependentEducationDetailChild>> GetDependentEducationDetailChilds(int FK_DependentEducationDetailId);
        Task CreateDependentEducationDetail(CreateDependentEducationDetailDto input);
        Task<string> UpdateDependentEducationDetail(UpdateDependentEducationDetailDto input);
        Task<DependentEducationDetailListDto> GetDependentEducationDetailByApplicationId(int ApplicationId);
        bool CheckDependentEducationDetailByApplicationId(int ApplicationId);
    }
}
