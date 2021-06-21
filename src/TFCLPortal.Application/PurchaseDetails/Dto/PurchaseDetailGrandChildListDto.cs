using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchoolClasses;

namespace TFCLPortal.PurchaseDetails.Dto
{
    [AutoMapFrom(typeof(PurchaseDetailGrandChild))]
    public class PurchaseDetailGrandChildListDto : EntityDto
    {
        public int Fk_PurchaseDetailChildId { get; set; }

        public string SrNo { get; set; }
        public string ItemName { get; set; }
        public string PerUnitPurchasePrice { get; set; }
        public string MonthlyPurchaseUnit { get; set; }
        public string TotalPurchase { get; set; }

    }
}
