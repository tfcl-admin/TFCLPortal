using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.NatureOfPayments
{
    public class NatureOfPaymentAppService : TFCLPortalAppServiceBase, INatureOfPaymentAppService
    {
        private readonly IRepository<NatureOfPayment> _NatureOfPaymentRepository;
        public NatureOfPaymentAppService(IRepository<NatureOfPayment> NatureOfPaymentRepository)
        {
            _NatureOfPaymentRepository = NatureOfPaymentRepository;
        }

        public async Task<ListResultDto<NatureOfPaymentListDto>> GetAllNatureOfPayments()
        {
            try
            {
                var NatureOfPayments = await _NatureOfPaymentRepository.GetAllListAsync();


                return new ListResultDto<NatureOfPaymentListDto>(
                    ObjectMapper.Map<List<NatureOfPaymentListDto>>(NatureOfPayments)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "NatureOfPayments"));
            }
        }

        public List<NatureOfPaymentListDto> GetAllList()
        {

            var NatureOfPayments = _NatureOfPaymentRepository.GetAllList();
            return ObjectMapper.Map<List<NatureOfPaymentListDto>>(NatureOfPayments);
        }
    }
}
