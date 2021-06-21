using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.BusinessNatures;

namespace TFCLPortal.DynamicDropdowns.ClientBusinessClassifications
{
    public class ClientBusinessClassificationAppService : TFCLPortalAppServiceBase, IClientBusinessClassificationAppService
    {
        private readonly IRepository<ClientBusinessClassification> _ClientBusinessClassificationRepository;
        public ClientBusinessClassificationAppService(IRepository<ClientBusinessClassification> repository)
        {
            _ClientBusinessClassificationRepository = repository;
        }
        public List<ClientBusinessClassificationListDto> GetAllList()
        {
            var ClientBusinessClassificationList = _ClientBusinessClassificationRepository.GetAllList();
            return ObjectMapper.Map<List<ClientBusinessClassificationListDto>>(ClientBusinessClassificationList);
        }

        public async Task<ListResultDto<ClientBusinessClassificationListDto>> GetAllClientBusinessClassification()
        {
            try
            {
                var ClientBusinessClassificationList = await _ClientBusinessClassificationRepository.GetAllListAsync();


                return new ListResultDto<ClientBusinessClassificationListDto>(
                    ObjectMapper.Map<List<ClientBusinessClassificationListDto>>(ClientBusinessClassificationList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Client Business Classification"));
            }
        }
    }
}
