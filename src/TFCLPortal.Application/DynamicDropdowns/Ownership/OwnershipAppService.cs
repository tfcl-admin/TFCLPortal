using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Ownership
{
   public  class OwnershipAppService : TFCLPortalAppServiceBase, IOwnershipAppService
    {
        private readonly IRepository<OwnershipStatus> _OwnershipStatusRepository;

        public OwnershipAppService(IRepository<OwnershipStatus> ownershipStatusRepository)
        {
            _OwnershipStatusRepository = ownershipStatusRepository;
        }

        public async Task<ListResultDto<OwnershipStatusListDto>> GetAllOwnershipStatus()
        {
            try
            {
                var ownerships = await _OwnershipStatusRepository.GetAllListAsync();



                return new ListResultDto<OwnershipStatusListDto>(
                    ObjectMapper.Map<List<OwnershipStatusListDto>>(ownerships)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Ownership Status"));
            }
        }


        public async Task CreateOwnershipStatus(CreateOwnershipStatusDto input)
        {
            try
            {
                var qualification = ObjectMapper.Map<OwnershipStatus>(input);
                await _OwnershipStatusRepository.InsertAsync(qualification);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Ownership Status"));
            }

        }

        public List<OwnershipStatusListDto> GetAllList()
        {

            var ownerships = _OwnershipStatusRepository.GetAllList();
            return ObjectMapper.Map<List<OwnershipStatusListDto>>(ownerships);
        }
    }
}
