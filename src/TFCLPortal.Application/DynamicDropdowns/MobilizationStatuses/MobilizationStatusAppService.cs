using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.MobilizationStatuses
{
    public class MobilizationStatusAppService : TFCLPortalAppServiceBase, IMobilizationStatusAppService
    {
        private readonly IRepository<MobilizationStatus> _mobilizationStatusRepository;
        public MobilizationStatusAppService(IRepository<MobilizationStatus> mobilizationStatusRepository)
        {
            _mobilizationStatusRepository = mobilizationStatusRepository;
        }

        public async Task CreateMobilizationStatus(CreateMobilizationStatusDto input)
        {
            try
            {
                var mobilizationStatus = ObjectMapper.Map<MobilizationStatus>(input);
                await _mobilizationStatusRepository.InsertAsync(mobilizationStatus);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Mobilization Status"));
            }
        }

        public List<MobilizationStatusListDto> GetAllList()
        {
            var mobilizationStatuslist = _mobilizationStatusRepository.GetAllList();
            return ObjectMapper.Map<List<MobilizationStatusListDto>>(mobilizationStatuslist);
        }

        public async Task<ListResultDto<MobilizationStatusListDto>> GetAllMobilizationStatus()
        {
            try
            {
                var mobilizationStatuslist = await _mobilizationStatusRepository.GetAllListAsync();


                return new ListResultDto<MobilizationStatusListDto>(
                    ObjectMapper.Map<List<MobilizationStatusListDto>>(mobilizationStatuslist)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "mobilization Status"));
            }
        }
    }
}
