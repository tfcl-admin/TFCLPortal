using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ReasonOfDeclines
{
    public class ReasonOfDeclineAppService : TFCLPortalAppServiceBase, IReasonOfDeclineAppService
    {
        private readonly IRepository<ReasonOfDecline> _reasonOfDeclineRepository;
        public ReasonOfDeclineAppService(IRepository<ReasonOfDecline> repository)
        {
            _reasonOfDeclineRepository = repository;
        }
        public async Task<ListResultDto<ReasonOfDeclineListDto>> GetAllReasonOfDeclines()
        {
            try
            {
                var reasonOfDeclineList = await _reasonOfDeclineRepository.GetAllListAsync();


                return new ListResultDto<ReasonOfDeclineListDto>(
                    ObjectMapper.Map<List<ReasonOfDeclineListDto>>(reasonOfDeclineList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Reason Of Decline"));
            }
        }


        public List<ReasonOfDeclineListDto> GetAllList()
        {
            var reasonOfDeclineList = _reasonOfDeclineRepository.GetAllList();
            return ObjectMapper.Map<List<ReasonOfDeclineListDto>>(reasonOfDeclineList);
        }

    }
}
