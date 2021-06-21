using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoansPurpose
{
    public class LoanPurposeAppService : TFCLPortalAppServiceBase, ILoanPurposeAppService
    {
        private readonly IRepository<LoanPurpose> _LoanPurposeRepository;

        public LoanPurposeAppService(IRepository<LoanPurpose> loanPurposeRepository)
        {
            _LoanPurposeRepository = loanPurposeRepository;
        }

        public async Task<ListResultDto<LoanPurposeListDto>> GetAllLoanPurposeAsync()
        {
            try
            {
                var loanPurposes = await _LoanPurposeRepository.GetAllListAsync();

                return new ListResultDto<LoanPurposeListDto>(
                    ObjectMapper.Map<List<LoanPurposeListDto>>(loanPurposes)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Loan Purpose"));
            }
        }

        public async Task CreateLoanPurposeAsync(CreateLoanPurposeDto input)
        {

            try
            {
                var loanPurpose = ObjectMapper.Map<LoanPurpose>(input);
                await _LoanPurposeRepository.InsertAsync(loanPurpose);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Loan Purpose"));
            }
        }

        public List<LoanPurposeListDto> GetAllList()
        {

            var loanList = _LoanPurposeRepository.GetAllList();
            return ObjectMapper.Map<List<LoanPurposeListDto>>(loanList);
        }
    }
}


