using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using TFCLPortal.DynamicDropdowns.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes
{
    public class OtherSourceOfIncomeAppService : TFCLPortalAppServiceBase, IOtherSourceOfIncomeAppService
    {
        private readonly IRepository<OtherSourceOfIncome> _OtherSourceOfIncomeRepository;
        public OtherSourceOfIncomeAppService(IRepository<OtherSourceOfIncome> repository)
        {
            _OtherSourceOfIncomeRepository = repository;
        }

        public List<OtherSourceOfIncomeListDto> GetAllList()
        {
            var OtherSourceOfIncomeList = _OtherSourceOfIncomeRepository.GetAllList();
            return ObjectMapper.Map<List<OtherSourceOfIncomeListDto>>(OtherSourceOfIncomeList);
        }

        public async Task<ListResultDto<OtherSourceOfIncomeListDto>> GetAllOtherSourceOfIncome()
        {
            try
            {
                var OtherSourceOfIncomeList = await _OtherSourceOfIncomeRepository.GetAllListAsync();


                return new ListResultDto<OtherSourceOfIncomeListDto>(
                    ObjectMapper.Map<List<OtherSourceOfIncomeListDto>>(OtherSourceOfIncomeList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Other Source Of Income"));
            }
        }

    }
}
