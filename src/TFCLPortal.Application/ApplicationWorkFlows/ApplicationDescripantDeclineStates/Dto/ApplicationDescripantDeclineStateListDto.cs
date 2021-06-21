using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto
{
    [AutoMapFrom(typeof(ApplicationDescripantDeclineState))]
    public class ApplicationDescripantDeclineStateListDto : EntityDto
    {
        public int Fk_UserId { get; set; }
        public bool IsActive { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public int Fk_WorkFlowId { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_BccId { get; set; }
    }
}
