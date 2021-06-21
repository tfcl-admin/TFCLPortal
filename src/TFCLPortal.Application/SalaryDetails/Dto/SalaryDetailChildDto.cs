using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.SalaryDetails.Dto
{
    [AutoMapFrom(typeof(SalaryDetailChild))]
    public class SalaryDetailChildDto : Entity<int>
    {
        public int Fk_SalaryDetailId { get; set; }
        public string CompanyName { get; set; }
        public string GrossSalary { get; set; }
        public string OtherBenifits { get; set; }
        public string IncentiveBonus { get; set; }
        public string TotalSalary { get; set; }
        public string Deductions { get; set; }
        public string NetSalary { get; set; }
    }
}
