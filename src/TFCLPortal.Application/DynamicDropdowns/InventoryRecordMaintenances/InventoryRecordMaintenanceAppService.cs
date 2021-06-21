using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances
{
    public class InventoryRecordMaintenanceAppService : TFCLPortalAppServiceBase, IInventoryRecordMaintenanceAppService
    {
        private readonly IRepository<InventoryRecordMaintenance> _InventoryRecordMaintenanceRepository;
        public InventoryRecordMaintenanceAppService(IRepository<InventoryRecordMaintenance> repository)
        {
            _InventoryRecordMaintenanceRepository = repository;
        }

        public List<InventoryRecordMaintenanceListDto> GetAllList()
        {
            var InventoryRecordMaintenanceList = _InventoryRecordMaintenanceRepository.GetAllList();
            return ObjectMapper.Map<List<InventoryRecordMaintenanceListDto>>(InventoryRecordMaintenanceList);
        }

        public async Task<ListResultDto<InventoryRecordMaintenanceListDto>> GetAllApplicantSources()
        {
            try
            {
                var InventoryRecordMaintenanceList = await _InventoryRecordMaintenanceRepository.GetAllListAsync();


                return new ListResultDto<InventoryRecordMaintenanceListDto>(
                    ObjectMapper.Map<List<InventoryRecordMaintenanceListDto>>(InventoryRecordMaintenanceList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Inventory Record Maintenance "));
            }
        }

    }
}
