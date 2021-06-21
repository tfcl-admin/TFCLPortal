using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.NatureOfBusinesses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(NatureOfBusiness))]
    public class CreateNatureOfBusinessDto
    {
        public string Name { get; set; }
    }
}
