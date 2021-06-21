using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ApplicantReputations
{
    public interface IApplicantReputationAppService : IApplicationService
    {
        Task<ListResultDto<ApplicantReputationListDto>> GetAllApplicantReputation();
        Task CreateApplicantReputation(CreateApplicantReputationDto input);
        List<ApplicantReputationListDto> GetAllList();
    }
}
