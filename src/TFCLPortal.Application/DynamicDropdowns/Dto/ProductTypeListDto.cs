using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ProductTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ProductType))]
    public class ProductTypeListDto : Entity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}
