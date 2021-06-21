using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TdsInventoryDetails;

namespace TFCLPortal.TdsInventoryDetails.Dto
{
    [AutoMapTo(typeof(TdsInventoryDetail))]

    public class CreateTdsInventoryDetailDto
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalePrice { get; set; }
        public string GrandTotalPurchasePrice { get; set; }
        public List<CreateTdsInventoryDetailChildDto> TdsInventoryDetailChilds { get; set; }
    }
}
