using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(RentAgreementSignatory))]
    public class RentAgreementSignatoryListDto : Entity
    {
        public string Name { get; set; }
    }
}
