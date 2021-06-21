using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TdsInventoryDetails;

namespace TFCLPortal.TdsInventoryDetails.Dto
{
    [AutoMapFrom(typeof(TdsInventoryDetail))]
    public class TdsInventoryDetailListDto : Entity 
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalePrice { get; set; }
        public string GrandTotalPurchasePrice { get; set; }
        public List<TdsInventoryDetailChildListDto> TdsInventoryDetailChilds { get; set; }
    }
}
