using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.UtilityBillPayments
{
    public interface IUtilityBillPaymentAppService : IApplicationService
    {
        Task<ListResultDto<UtilityBillPaymentListDto>> GetAllUtilityBillPayment();
        Task CreateUtilityBillPayment(CreateUtilityBillPaymentDto input);
        List<UtilityBillPaymentListDto> GetAllList();
    }
}
