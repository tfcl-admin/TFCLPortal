using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ClientStatus))]
    public class ClientStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}

