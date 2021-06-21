using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoanTenureRequireds
{
    public class LoanTenureRequiredAppService : TFCLPortalAppServiceBase, ILoanTenureRequiredAppService
    {
        private readonly IRepository<LoanTenureRequired> _loanTenureRequiredRepository;

        public LoanTenureRequiredAppService(IRepository<LoanTenureRequired> loanTenureRequiredRepository)
        {
            _loanTenureRequiredRepository = loanTenureRequiredRepository;
        }
        public async Task CreateLoanTenureRequired(CreateLoanTenureRequiredDto input)
        {
            try
            {
                var LoanTenureRequired = ObjectMapper.Map<LoanTenureRequired>(input);
                await _loanTenureRequiredRepository.InsertAsync(LoanTenureRequired);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "LoanTenureRequired"));
            }
        }

        public List<LoanTenureRequiredListDto> GetAllList()
        {
            var LoanTenureRequired = _loanTenureRequiredRepository.GetAllList();
            return ObjectMapper.Map<List<LoanTenureRequiredListDto>>(LoanTenureRequired);
        }

        public async Task<ListResultDto<LoanTenureRequiredListDto>> GetAllLoanTenureRequired()
        {
            try
            {
                var LoanTenureRequired = await _loanTenureRequiredRepository.GetAllListAsync();


                return new ListResultDto<LoanTenureRequiredListDto>(
                    ObjectMapper.Map<List<LoanTenureRequiredListDto>>(LoanTenureRequired)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "LoanTenureRequired"));
            }
        }
    }
}
