using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FinalWorkflows.Dto
{
    [AutoMapTo(typeof(FinalWorkflow))]
    public class CreateFinalWorkflowDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int ActionBy { get; set; }
        public string Action { get; set; }
        public bool isActive { get; set; }
        public string ApplicationState { get; set; }
    }
}
