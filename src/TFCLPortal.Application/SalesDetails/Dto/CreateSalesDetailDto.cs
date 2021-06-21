using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SalesDetails.Dto
{
    [AutoMapTo(typeof(SalesDetail))]
    public class CreateSalesDetailDto
    {
        public int ApplicationId { get; set; }
        public string grandTotalSalesToBeConsidered { get; set; }
        public List<CreateSalesDetailChildDto> SalesDetailChild { get; set; }
    }
}
