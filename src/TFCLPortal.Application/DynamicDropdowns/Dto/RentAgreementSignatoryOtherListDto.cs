using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatoryOthers;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(RentAgreementSignatoryOther))]
    public class RentAgreementSignatoryOtherListDto : Entity
    {
        public string Name { get; set; }
    }
}
