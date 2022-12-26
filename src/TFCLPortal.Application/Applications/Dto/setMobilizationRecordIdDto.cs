using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications.Dto
{
    public class setMobilizationRecordIdDto
    {

        public List<records> records { get; set; }
    }

    public class records
    {
        public int ApplicationId { get; set; }
        public string mobilizationRecordId { get; set; }
    }


}
