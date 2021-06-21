using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchoolClasses;

namespace TFCLPortal.SalesDetails.Dto
{
    [AutoMapFrom(typeof(SalesDetailGrandChild))]
    public class SalesDetailGrandChildListDto : EntityDto
    {
        public int Fk_SalesDetailChildId { get; set; }
        public string SrNo { get; set; }
        public string ItemName { get; set; }
        public string PerUnitSalePrice { get; set; }
        public string MonthlySaleUnit { get; set; }
        public string TotalSale { get; set; }
    }
}
