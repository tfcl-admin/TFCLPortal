using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BADataChecks.Dto
{
    [AutoMapTo(typeof(BADataCheck))]
    public class CreateBADataCheckDto
    {
        public int Fk_UserId { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
        public int SDE_UserId { get; set; }
        public int BA_UserId { get; set; }
        public string DocumentName { get; set; }

        public string DocumentKey { get; set; }
        public string DocumentUrl { get; set; }
        public string BaseUrl { get; set; }
    }
}
