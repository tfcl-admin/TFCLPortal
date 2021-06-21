using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlows.Dto
{
    [AutoMapFrom(typeof(WorkFlow))]
    public  class WorkFlowListDto : EntityDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
