using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.RelationshipWithApplicants
{
    public class RelationshipWithApplicantAppService : TFCLPortalAppServiceBase, IRelationshipWithApplicantAppService
    {
        private readonly IRepository<RelationshipWithApplicant> _relationshipWithApplicantRepository;

        public RelationshipWithApplicantAppService(IRepository<RelationshipWithApplicant> relationshipWithApplicantRepository)
        {
            _relationshipWithApplicantRepository = relationshipWithApplicantRepository;
        }


        public List<RelationshipWithApplicantListDto> GetAllList()
        {
            var relationshipWithApplicantList = _relationshipWithApplicantRepository.GetAllList();
            return ObjectMapper.Map<List<RelationshipWithApplicantListDto>>(relationshipWithApplicantList);
        }

      
        public async Task<ListResultDto<RelationshipWithApplicantListDto>> GetAllRelationshipWithApplicants()
        {
            try
            {
                var relationshipWithApplicantList = await _relationshipWithApplicantRepository.GetAllListAsync();


                return new ListResultDto<RelationshipWithApplicantListDto>(
                    ObjectMapper.Map<List<RelationshipWithApplicantListDto>>(relationshipWithApplicantList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Reason Of Decline"));
            }
        }
    }
}
