using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CreditCommettees
{
    public class CreditCommetteeAppService : TFCLPortalAppServiceBase, ICreditCommetteeAppService
    {
        private readonly IRepository<CreditCommettee> _creditCommetteerepo;
        public CreditCommetteeAppService(IRepository<CreditCommettee> creditCommettee)
        {
            _creditCommetteerepo = creditCommettee;
        }

        public async Task CreateCreditCommettee(CreateCreditCommetteeDto input)
        {
            try
            {
                var creditCommettee = ObjectMapper.Map<CreditCommettee>(input);
                await _creditCommetteerepo.InsertAsync(creditCommettee);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "CreditCommettee"));
            }
        }

        public async Task<ListResultDto<CreditCommetteeListDto>> GetAllCreditCommettee()
        {
            try
            {
                var creditCommettee = await _creditCommetteerepo.GetAllListAsync();


                return new ListResultDto<CreditCommetteeListDto>(
                    ObjectMapper.Map<List<CreditCommetteeListDto>>(creditCommettee)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "CreditCommettee"));
            }
        }

        public List<CreditCommetteeListDto> GetAllList()
        {

            var creditCommetteelist = _creditCommetteerepo.GetAllList();
            return ObjectMapper.Map<List<CreditCommetteeListDto>>(creditCommetteelist);
        }
    }
}
