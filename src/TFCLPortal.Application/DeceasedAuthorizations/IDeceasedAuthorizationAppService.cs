using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeceasedAuthorizations.Dto;

namespace TFCLPortal.DeceasedAuthorizations
{
   public interface IDeceasedAuthorizationAppService : IApplicationService
    {
        Task<string> Create(CreateDeceasedAuthorization createDeceasedAuthorization);
        Task<string> Update(EditDeceasedAuthorization editDeceasedAuthorization);
        Task<DeceasedAuthorizationListDto> GetDeceasedAuthorizationById(int Id);
        Task<List<DeceasedAuthorizationListDto>> GetDeceasedAuthorizationByApplicationId(int ApplicationId);
        bool CheckDeceasedAuthorizationByApplicationId(int ApplicationId);
        Task<List<DeceasedAuthorizationListDto>> GetAllDeceasedAuthorizations();
    }
}
