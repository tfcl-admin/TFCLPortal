using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessDetailsTDS.Dto
{
    public class CreateParentBusinessDetailTDSDto
    {
        public List<CreateBusinessDetailTDSDto> businessDetailTds { get; set; }
    }
}
