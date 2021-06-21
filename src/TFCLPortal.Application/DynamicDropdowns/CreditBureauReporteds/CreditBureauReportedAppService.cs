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

namespace TFCLPortal.DynamicDropdowns.CreditBureauReporteds
{
    public class CreditBureauReportedAppService : TFCLPortalAppServiceBase, ICreditBureauReportedAppService
    {
        private readonly IRepository<CreditBureauReported> _creditBureauReportedRepository;
        public CreditBureauReportedAppService(IRepository<CreditBureauReported> repository)
        {
            _creditBureauReportedRepository = repository;
        }
        public async Task<ListResultDto<CreditBureauReportedListDto>> GetAllCreditBureauReporteds()
        {
            try
            {
                var CreditBureauReportedList = await _creditBureauReportedRepository.GetAllListAsync();


                return new ListResultDto<CreditBureauReportedListDto>(
                    ObjectMapper.Map<List<CreditBureauReportedListDto>>(CreditBureauReportedList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Credit Bureau Reported"));
            }
        }


        public List<CreditBureauReportedListDto> GetAllList()
        {
            var CreditBureauReportedList = _creditBureauReportedRepository.GetAllList();
            return ObjectMapper.Map<List<CreditBureauReportedListDto>>(CreditBureauReportedList);
        }

    }
}
