using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SalaryDetails.Dto
{
    [AutoMapTo(typeof(SalaryDetail))]
    public class UpdateSalaryDetailDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalary { get; set; }
        public List<UpdateSalaryDetailChildDto> SalaryDetailList { get; set; }
    }
}
