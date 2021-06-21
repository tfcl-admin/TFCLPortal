using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.PurchaseDetails.Dto
{
    [AutoMapTo(typeof(PurchaseDetail))]
    public class CreatePurchaseDetailDto
    {
        public int ApplicationId { get; set; }
        public string grandTotalPurchaseToBeConsidered { get; set; }
        public List<CreatePurchaseDetailChildDto> PurchaseDetailChild { get; set; }
    }
}
