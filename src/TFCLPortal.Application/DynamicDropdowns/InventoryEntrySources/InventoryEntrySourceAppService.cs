using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.InventoryEntrySources
{
    public class InventoryEntrySourceAppService : TFCLPortalAppServiceBase, IInventoryEntrySourceAppService
    {
        private readonly IRepository<InventoryEntrySource> _InventoryEntrySourceRepository;
        public InventoryEntrySourceAppService(IRepository<InventoryEntrySource> repository)
        {
            _InventoryEntrySourceRepository = repository;
        }

        public List<InventoryEntrySourceListDto> GetAllList()
        {
            var InventoryEntrySourceList = _InventoryEntrySourceRepository.GetAllList();
            return ObjectMapper.Map<List<InventoryEntrySourceListDto>>(InventoryEntrySourceList);
        }

        public async Task<ListResultDto<InventoryEntrySourceListDto>> GetAllApplicantSources()
        {
            try
            {
                var InventoryEntrySourceList = await _InventoryEntrySourceRepository.GetAllListAsync();


                return new ListResultDto<InventoryEntrySourceListDto>(
                    ObjectMapper.Map<List<InventoryEntrySourceListDto>>(InventoryEntrySourceList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Respondant Designation"));
            }
        }

    }
}
