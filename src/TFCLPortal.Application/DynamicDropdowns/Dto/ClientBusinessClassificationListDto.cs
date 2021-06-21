using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ClientBusinessClassifications;
using TFCLPortal.TDSBusinessNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ClientBusinessClassification))]
    public class ClientBusinessClassificationListDto : Entity
    {
        public string Name { get; set; }

    }
}
