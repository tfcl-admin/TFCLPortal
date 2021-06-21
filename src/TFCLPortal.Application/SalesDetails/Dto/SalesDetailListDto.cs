using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SalesDetails.Dto
{
    [AutoMapFrom(typeof(SalesDetail))]
    public class SalesDetailListDto : EntityDto
    {

        public int ApplicationId { get; set; }
        public string grandTotalSalesToBeConsidered { get; set; }
        public List<SalesDetailChildListDto> SalesDetailChild { get; set; }

    }
}
