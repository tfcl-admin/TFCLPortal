using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BccStates.Dto
{
    [AutoMapTo(typeof(BccState))]
    public class CreateBccStateDto
    {
        public int Fk_UserId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_BccId { get; set; }
    }
}
