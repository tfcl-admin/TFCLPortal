using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ReferenceChecks
{
    public class ReferenceCheckAppService : TFCLPortalAppServiceBase, IReferenceCheckAppService
    {
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        public ReferenceCheckAppService(IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _referenceCheckRepository = referenceCheckRepository;
        }
        public async Task CreateReferenceCheck(CreateReferenceCheckDto input)
        {
            try
            {
                var ReferenceChecks = ObjectMapper.Map<ReferenceCheck>(input);
                await _referenceCheckRepository.InsertAsync(ReferenceChecks);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Reference Checks"));
            }
        }

        public List<ReferenceCheckListDto> GetAllList()
        {
            var ReferenceChecks = _referenceCheckRepository.GetAllList();
            return ObjectMapper.Map<List<ReferenceCheckListDto>>(ReferenceChecks);
        }

        public async Task<ListResultDto<ReferenceCheckListDto>> GetAllReferenceCheck()
        {
            try
            {
                var ReferenceChecks = await _referenceCheckRepository.GetAllListAsync();



                return new ListResultDto<ReferenceCheckListDto>(
                    ObjectMapper.Map<List<ReferenceCheckListDto>>(ReferenceChecks)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Reference Check"));
            }
        }
    }
}
