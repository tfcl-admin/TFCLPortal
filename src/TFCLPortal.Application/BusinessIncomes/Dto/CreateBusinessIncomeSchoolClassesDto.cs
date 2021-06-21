using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessIncomeSchoolClasses;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncomeSchoolClass))]
    public class CreateBusinessIncomeSchoolClassesDto
    {
        public int Fk_BusinessIncomeChild { get; set; }
        public string ClassName { get; set; }
        
        public string MaleStudents { get; set; }
        public string FemaleStudents { get; set; }
        public string NoOfStudents { get; set; }

        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
    }
}
