using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.CoApplicantDetails.Dto;

namespace TFCLPortal.CoApplicantDetails
{
   public interface ICoApplicantDetailAppService : IApplicationService
    {
        Task<string> Create(CreateCoApplicantDetailInput createCoApplicantDetailInpt, int applicationId);
        Task<string> Update(EditCoApplicantDetailInput input);
        Task<List<CoApplicantDetailListDto>> GetCoApplicantDetailById(int Id);
        Task<List<CoApplicantDetailListDto>> GetCoApplicantDetailByApplicationId(int ApplicationId);
        bool CheckCoApplicantDetailByApplicationId(int ApplicationId);
    }
}
