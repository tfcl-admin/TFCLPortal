using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.MaritalStatuses
{
    public class MaritalStatusAppService : TFCLPortalAppServiceBase, IMaritalStatusAppService
    {
        private readonly IRepository<MaritalStatus> _maritalStatusesRepository;
        public MaritalStatusAppService(IRepository<MaritalStatus> maritalStatusesRepository)
        {
            _maritalStatusesRepository = maritalStatusesRepository;
        }
        public async Task CreateMaritalStatus(CreateMaritalStatusDto input)
        {
            try
            {
                var maritalStatus = ObjectMapper.Map<MaritalStatus>(input);
                await _maritalStatusesRepository.InsertAsync(maritalStatus);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "MaritalStatus"));
            }
        }

        public async Task<ListResultDto<MaritalStatusListDto>> GetAllMaritalStatus()
        {
            try
            {
                var maritalStatus = await _maritalStatusesRepository.GetAllListAsync();


                return new ListResultDto<MaritalStatusListDto>(
                    ObjectMapper.Map<List<MaritalStatusListDto>>(maritalStatus)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "MaritalStatus"));
            }
        }

        public List<MaritalStatusListDto> GetAllList()
        {

            var maritalStatuslist = _maritalStatusesRepository.GetAllList();
            return ObjectMapper.Map<List<MaritalStatusListDto>>(maritalStatuslist);
        }
    }
}
