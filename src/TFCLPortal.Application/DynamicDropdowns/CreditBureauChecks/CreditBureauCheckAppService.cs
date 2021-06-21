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

namespace TFCLPortal.DynamicDropdowns.CreditBureauChecks
{
    public class CreditBureauCheckAppService : TFCLPortalAppServiceBase, ICreditBureauCheckAppService
    {
        private readonly IRepository<CreditBureauCheck> _creditBureauCheckRepository;
        public CreditBureauCheckAppService(IRepository<CreditBureauCheck> repository)
        {
            _creditBureauCheckRepository = repository;
        }
        public async Task<ListResultDto<CreditBureauCheckListDto>> GetAllCreditBureauChecks()
        {
            try
            {
                var CreditBureauCheckList = await _creditBureauCheckRepository.GetAllListAsync();


                return new ListResultDto<CreditBureauCheckListDto>(
                    ObjectMapper.Map<List<CreditBureauCheckListDto>>(CreditBureauCheckList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Credit Bureau Check"));
            }
        }


        public List<CreditBureauCheckListDto> GetAllList()
        {
            var CreditBureauCheckList = _creditBureauCheckRepository.GetAllList();
            return ObjectMapper.Map<List<CreditBureauCheckListDto>>(CreditBureauCheckList);
        }

    }
}
