using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.PaymentsFrquency
{
   public interface IPaymentFrequencyAppService : IApplicationService
    {
        Task<ListResultDto<PaymentFrequencyListDto>> GetAllPaymentFrequency();
        Task CreatePaymentFrequency(CreatePaymentFrequencyDto input);
        List<PaymentFrequencyListDto> GetAllList();
    }
}
