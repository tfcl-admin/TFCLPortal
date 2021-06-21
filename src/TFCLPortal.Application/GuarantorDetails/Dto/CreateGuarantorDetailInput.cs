using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.GuarantorDetails.Dto
{
    [AutoMapTo(typeof(GuarantorDetail))]
    public class CreateGuarantorDetailInput
    {
        public List<EditGuarantorDetailinput> CreategurantorInput { get; set; }
    }
}
