using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.UtilityBillPayments
{
    public class UtilityBillPaymentAppService : TFCLPortalAppServiceBase, IUtilityBillPaymentAppService
    {
        private readonly IRepository<UtilityBillPayment> _utilityBillPaymentrepo;
        public UtilityBillPaymentAppService(IRepository<UtilityBillPayment> utilityBillPayment)
        {
            _utilityBillPaymentrepo = utilityBillPayment;
        }

        public async Task CreateUtilityBillPayment(CreateUtilityBillPaymentDto input)
        {
            try
            {
                var utilityBillPayment = ObjectMapper.Map<UtilityBillPayment>(input);
                await _utilityBillPaymentrepo.InsertAsync(utilityBillPayment);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "UtilityBillPayment"));
            }
        }

        public async Task<ListResultDto<UtilityBillPaymentListDto>> GetAllUtilityBillPayment()
        {
            try
            {
                var utilityBillPayment = await _utilityBillPaymentrepo.GetAllListAsync();


                return new ListResultDto<UtilityBillPaymentListDto>(
                    ObjectMapper.Map<List<UtilityBillPaymentListDto>>(utilityBillPayment)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "UtilityBillPayment"));
            }
        }

        public List<UtilityBillPaymentListDto> GetAllList()
        {

            var utilityBillPaymentList = _utilityBillPaymentrepo.GetAllList();
            return ObjectMapper.Map<List<UtilityBillPaymentListDto>>(utilityBillPaymentList);
        }
    }
}
