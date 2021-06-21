using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.FundSources;


namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(FundSource))]
    public class CreateFundSourceDto
    {
        public string Name { get; set; }
    }
}
