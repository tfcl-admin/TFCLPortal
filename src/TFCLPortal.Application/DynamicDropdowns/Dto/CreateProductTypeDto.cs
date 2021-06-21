using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ProductTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(ProductType))]
    public class CreateProductTypeDto
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}
