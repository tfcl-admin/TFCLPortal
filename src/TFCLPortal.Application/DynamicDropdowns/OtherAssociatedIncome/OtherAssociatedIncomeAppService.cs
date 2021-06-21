using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes
{
    public class OtherAssociatedIncomeAppService : TFCLPortalAppServiceBase, IOtherAssociatedIncomeAppService
    {
        private readonly IRepository<OtherAssociatedIncome> _OtherAssociatedIncomeRepository;
        public OtherAssociatedIncomeAppService(IRepository<OtherAssociatedIncome> OtherAssociatedIncomeRepository)
        {
            _OtherAssociatedIncomeRepository = OtherAssociatedIncomeRepository;

        }
        public async Task<ListResultDto<OtherAssociatedIncomeListDto>> GetAllOtherAssociatedIncomes()
        {
            try
            {
                var OtherAssociatedIncome = await _OtherAssociatedIncomeRepository.GetAllListAsync();


                return new ListResultDto<OtherAssociatedIncomeListDto>(
                    ObjectMapper.Map<List<OtherAssociatedIncomeListDto>>(OtherAssociatedIncome)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Other Associated Income"));
            }
        }

        public List<OtherAssociatedIncomeListDto> GetAllList()
        {
            var OtherAssociatedIncome = _OtherAssociatedIncomeRepository.GetAllList();
            return ObjectMapper.Map<List<OtherAssociatedIncomeListDto>>(OtherAssociatedIncome);
        }

    }
}
