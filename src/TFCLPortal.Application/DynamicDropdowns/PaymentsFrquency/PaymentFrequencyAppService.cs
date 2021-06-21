using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;

namespace TFCLPortal.DynamicDropdowns.PaymentsFrquency
{
   public class PaymentFrequencyAppService : TFCLPortalAppServiceBase, IPaymentFrequencyAppService
    {
        private readonly IRepository<PaymentFrequency> _PaymentFrequencyRepository;

        public PaymentFrequencyAppService(IRepository<PaymentFrequency> paymentFrequencyRepository)
        {
            _PaymentFrequencyRepository = paymentFrequencyRepository;
        }

        public async Task<ListResultDto<PaymentFrequencyListDto>> GetAllPaymentFrequency()
        {
            try
            {
                var paymentFrequency = await _PaymentFrequencyRepository.GetAllListAsync();



                return new ListResultDto<PaymentFrequencyListDto>(
                    ObjectMapper.Map<List<PaymentFrequencyListDto>>(paymentFrequency)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Payment Frequency"));
            }
        }


        public async Task CreatePaymentFrequency(CreatePaymentFrequencyDto input)
        {
            try
            {
                var paymentFrequency = ObjectMapper.Map<PaymentFrequency>(input);
                await _PaymentFrequencyRepository.InsertAsync(paymentFrequency);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Payment Frequency"));
            }

        }

        public List<PaymentFrequencyListDto> GetAllList()
        {

            var paymentFrequencies = _PaymentFrequencyRepository.GetAllList();
            return ObjectMapper.Map<List<PaymentFrequencyListDto>>(paymentFrequencies);
        }
    }
}

