using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.TdsInventoryDetailGrandChilds;

namespace TFCLPortal.TdsInventoryDetails.Dto
{
    [AutoMapFrom(typeof(TdsInventoryDetailGrandChild))]
    public class TdsInventoryDetailGrandChildListDto : Entity
    {
        public int Fk_TdsInventoryDetailChild { get; set; }
        public string ItemName { get; set; }
        public string qty { get; set; }
        public string PurchasedPrice { get; set; }
        public string TotalPurchasedPrice { get; set; }
        public string SalePrice { get; set; }
        public string TotalSalePrice { get; set; }
        public string GrossMargin { get; set; }
        public string PhysicallyVerified { get; set; }
        public string VariancePercentage { get; set; }
    }
}