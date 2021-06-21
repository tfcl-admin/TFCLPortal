using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessIncomeSchools;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncomeSchool))]
    public class UpdateBusinessChildDto : Entity<int>
    {
        public string ClassName { get; set; }
        public string NoOfStudents { get; set; }
        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
        public int Fk_BusinessIncome { get; set; }
    }
}
