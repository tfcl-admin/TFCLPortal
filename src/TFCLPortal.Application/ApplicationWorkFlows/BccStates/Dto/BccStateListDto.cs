using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BccStates.Dto
{
    [AutoMapFrom(typeof(BccState))]
    public class BccStateListDto : FullAuditedEntityDto
    {
        public int Fk_UserId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_BccId { get; set; }
    }
}
