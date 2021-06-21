using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlows.Dto
{
    [AutoMapTo(typeof(WorkFlow))]
    public class CreateWorkFlowDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
