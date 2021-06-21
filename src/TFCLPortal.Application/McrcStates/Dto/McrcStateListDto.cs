using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.McrcStates.Dto
{
    [AutoMapFrom(typeof(McrcState))]
    public class McrcStateListDto : FullAuditedEntityDto
    {
        public int Fk_UserId { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_McrcId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
