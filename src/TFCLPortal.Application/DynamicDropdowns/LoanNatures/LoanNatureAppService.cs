using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoanNatures
{
    public class LoanNatureAppService : TFCLPortalAppServiceBase, ILoanNatureAppService
    {
        private readonly IRepository<LoanNature> _LoanNatureRepository;
        public LoanNatureAppService(IRepository<LoanNature> LoanNatureRepository)
        {
            _LoanNatureRepository = LoanNatureRepository;
        }
        public List<LoanNatureListDto> GetAllList()
        {
            var LoanNatures = _LoanNatureRepository.GetAllList();
            return ObjectMapper.Map<List<LoanNatureListDto>>(LoanNatures);
        }

        public async Task<ListResultDto<LoanNatureListDto>> GetAllLoanNatureAsync()
        {
            try
            {
                var LoanNatures = await _LoanNatureRepository.GetAllListAsync();

                return new ListResultDto<LoanNatureListDto>(
                    ObjectMapper.Map<List<LoanNatureListDto>>(LoanNatures)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Loan Purpose"));
            }
        }
    }
}
