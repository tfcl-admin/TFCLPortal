using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ReasonForNotBeingInteresteds
{
    public class ReasonForNotBeingInterestedAppService : TFCLPortalAppServiceBase, IReasonForNotBeingInterestedAppService
    {
        private readonly IRepository<ReasonForNotBeingInterested> _ReasonForNotBeingInterestedRepository;
        public ReasonForNotBeingInterestedAppService(IRepository<ReasonForNotBeingInterested> repository)
        {
            _ReasonForNotBeingInterestedRepository = repository;
        }

        public List<ReasonForNotBeingInterestedListDto> GetAllList()
        {
            var ReasonForNotBeingInterestedList = _ReasonForNotBeingInterestedRepository.GetAllList();
            return ObjectMapper.Map<List<ReasonForNotBeingInterestedListDto>>(ReasonForNotBeingInterestedList);
        }

        public async Task<ListResultDto<ReasonForNotBeingInterestedListDto>> GetAllApplicantSources()
        {
            try
            {
                var ReasonForNotBeingInterestedList = await _ReasonForNotBeingInterestedRepository.GetAllListAsync();


                return new ListResultDto<ReasonForNotBeingInterestedListDto>(
                    ObjectMapper.Map<List<ReasonForNotBeingInterestedListDto>>(ReasonForNotBeingInterestedList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Reason For Not Being Interested"));
            }
        }

    }
}
