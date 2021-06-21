using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoanPurposeClassifications
{
    public class LoanPurposeClassificationAppService : TFCLPortalAppServiceBase, ILoanPurposeClassificationAppService
    {
        private readonly IRepository<LoanPurposeClassification> _loanPurposeClassificationRepository;
        public LoanPurposeClassificationAppService(IRepository<LoanPurposeClassification> repository)
        {
            _loanPurposeClassificationRepository = repository;
        }
        public async Task<ListResultDto<LoanPurposeClassificationListDto>> GetAllLoanPurposeClassifications()
        {
            try
            {
                var loanPurposeClassificationList = await _loanPurposeClassificationRepository.GetAllListAsync();


                return new ListResultDto<LoanPurposeClassificationListDto>(
                    ObjectMapper.Map<List<LoanPurposeClassificationListDto>>(loanPurposeClassificationList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "loan Purpose Classification"));
            }
        }


        public List<LoanPurposeClassificationListDto> GetAllList()
        {
            var loanPurposeClassificationList = _loanPurposeClassificationRepository.GetAllList();
            return ObjectMapper.Map<List<LoanPurposeClassificationListDto>>(loanPurposeClassificationList);
        }

    }
}
