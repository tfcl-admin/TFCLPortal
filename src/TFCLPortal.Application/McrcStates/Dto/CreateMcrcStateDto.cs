using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.McrcStates.Dto
{
    [AutoMapTo(typeof(McrcState))]
    public class CreateMcrcStateDto
    {
        public int Fk_UserId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_McrcId { get; set; }
    }
}
