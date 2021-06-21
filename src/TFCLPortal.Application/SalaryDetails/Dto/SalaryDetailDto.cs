using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SalaryDetails.Dto
{
    [AutoMapFrom(typeof(SalaryDetail))]
    public class SalaryDetailDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalary { get; set; }
        public List<SalaryDetailChildDto> SalaryDetailList { get; set; }
    }
}
