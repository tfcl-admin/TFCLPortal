using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.BusinessLegalStatuses
{
    public class BusinessLegalStatusAppService : TFCLPortalAppServiceBase, IBusinessLegalStatusAppService
    {
        private readonly IRepository<BusinessLegalStatus> _businessLegalStatusrepo;
        public BusinessLegalStatusAppService(IRepository<BusinessLegalStatus> businessLegalStatus)
        {
            _businessLegalStatusrepo = businessLegalStatus;
        }
        public async Task CreateBusinessLegalStatus(CreateBusinessLegalStatusDto input)
        {
            try
            {
                var businessLegalStatus = ObjectMapper.Map<BusinessLegalStatus>(input);
                await _businessLegalStatusrepo.InsertAsync(businessLegalStatus);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "BusinessLegalStatus"));
            }
        }

        public async Task<ListResultDto<BusinessLegalStatusListDto>> GetAllBusinessLegalStatus()
        {
            try
            {
                var businessLegalStatus = await _businessLegalStatusrepo.GetAllListAsync();


                return new ListResultDto<BusinessLegalStatusListDto>(
                    ObjectMapper.Map<List<BusinessLegalStatusListDto>>(businessLegalStatus)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "BusinessLegalStatus"));
            }
        }

        public List<BusinessLegalStatusListDto> GetAllList()
        {

            var businessLegalStatuslist = _businessLegalStatusrepo.GetAllList();
            return ObjectMapper.Map<List<BusinessLegalStatusListDto>>(businessLegalStatuslist);
        }
    }
}
