using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using TFCLPortal.DynamicDropdowns.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TFCLPortal.Banks;

namespace TFCLPortal.DynamicDropdowns.Banks
{ 
    public class BankAppService : TFCLPortalAppServiceBase, IBankAppService
    {
        private readonly IRepository<Bank> _banksRepository;
       
        public BankAppService(IRepository<Bank> banksRepository)
        {
            _banksRepository = banksRepository;
        }

        public List<BankListDto> GetAllList()
        {
            var BanksList = _banksRepository.GetAllList();
            return ObjectMapper.Map<List<BankListDto>>(BanksList);
        }

        public async Task<ListResultDto<BankListDto>> GetAllBanks()
        {
            try
            {
                var BanksList = await _banksRepository.GetAllListAsync();


                return new ListResultDto<BankListDto>(
                    ObjectMapper.Map<List<BankListDto>>(BanksList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Bank"));
            }
        }

    }
}
