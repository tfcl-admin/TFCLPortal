using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessDetailsTDS.Dto
{
    public class ParentBusinessDetailTDSListDto
    {
        public int ApplicationId { get; set; }
        public List<BusinessDetailTDSListDto> businessDetailTds { get; set; }
    }
}
