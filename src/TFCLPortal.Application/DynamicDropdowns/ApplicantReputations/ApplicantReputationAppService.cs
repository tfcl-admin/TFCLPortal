using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ApplicantReputations
{
    public class ApplicantReputationAppService : TFCLPortalAppServiceBase, IApplicantReputationAppService
    {
        private readonly IRepository<ApplicantReputation> _applicantReputationsrepo;
        public ApplicantReputationAppService(IRepository<ApplicantReputation> applicantReputations)
        {
            _applicantReputationsrepo = applicantReputations;
        }

        public async Task CreateApplicantReputation(CreateApplicantReputationDto input)
        {
            try
            {
                var applicantReputation = ObjectMapper.Map<ApplicantReputation>(input);
                await _applicantReputationsrepo.InsertAsync(applicantReputation);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "ApplicantReputations"));
            }
        }

        public async Task<ListResultDto<ApplicantReputationListDto>> GetAllApplicantReputation()
        {
            try
            {
                var applicantReputation = await _applicantReputationsrepo.GetAllListAsync();


                return new ListResultDto<ApplicantReputationListDto>(
                    ObjectMapper.Map<List<ApplicantReputationListDto>>(applicantReputation)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "CreditCommettee"));
            }
        }

        public List<ApplicantReputationListDto> GetAllList()
        {

            var applicantReputationlist = _applicantReputationsrepo.GetAllList();
            return ObjectMapper.Map<List<ApplicantReputationListDto>>(applicantReputationlist);
        }
    }
}
