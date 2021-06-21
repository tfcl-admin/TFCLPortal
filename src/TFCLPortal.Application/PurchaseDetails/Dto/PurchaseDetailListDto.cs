using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.PurchaseDetails.Dto
{
    [AutoMapFrom(typeof(PurchaseDetail))]
    public class PurchaseDetailListDto : EntityDto
    {

        public int ApplicationId { get; set; }
        public string grandTotalPurchaseToBeConsidered { get; set; }
        public List<PurchaseDetailChildListDto> PurchaseDetailChild { get; set; }

    }
}
