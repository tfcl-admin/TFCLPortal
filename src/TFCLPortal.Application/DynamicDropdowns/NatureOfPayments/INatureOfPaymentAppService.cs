using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.NatureOfPayments
{
    public interface INatureOfPaymentAppService : IApplicationService
    {
        Task<ListResultDto<NatureOfPaymentListDto>> GetAllNatureOfPayments();
        List<NatureOfPaymentListDto> GetAllList();
    }
}
