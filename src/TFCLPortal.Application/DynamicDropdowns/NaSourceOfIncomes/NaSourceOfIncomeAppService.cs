using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.NaSourceOfIncomes
{
    public class NaSourceOfIncomeAppService : TFCLPortalAppServiceBase, INaSourceOfIncomeAppService
    {
        private readonly IRepository<NaSourceOfIncome> _NaSourceOfIncomeRepository;
        public NaSourceOfIncomeAppService(IRepository<NaSourceOfIncome> repository)
        {
            _NaSourceOfIncomeRepository = repository;
        }

        public List<NaSourceOfIncomeListDto> GetAllList()
        {
            var NaSourceOfIncomeList = _NaSourceOfIncomeRepository.GetAllList();
            return ObjectMapper.Map<List<NaSourceOfIncomeListDto>>(NaSourceOfIncomeList);
        }

        public async Task<ListResultDto<NaSourceOfIncomeListDto>> GetAllNaSourceOfIncome()
        {
            try
            {
                var NaSourceOfIncomeList = await _NaSourceOfIncomeRepository.GetAllListAsync();


                return new ListResultDto<NaSourceOfIncomeListDto>(
                    ObjectMapper.Map<List<NaSourceOfIncomeListDto>>(NaSourceOfIncomeList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Other Source Of Income"));
            }
        }
    }
}
