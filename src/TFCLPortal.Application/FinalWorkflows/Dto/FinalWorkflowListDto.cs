using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FinalWorkflows.Dto
{
    [AutoMapFrom(typeof(FinalWorkflow))]
    public class FinalWorkflowListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public int ActionBy { get; set; }
        public string UserFullName { get; set; }
        public string Action { get; set; }
        public bool isActive { get; set; }
        public string ApplicationState { get; set; }
    }
}
