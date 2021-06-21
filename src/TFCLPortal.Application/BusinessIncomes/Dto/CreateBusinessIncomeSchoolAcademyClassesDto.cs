using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessIncomeAcademyClasses;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncomeSchoolAcademyClass))]
    public class CreateBusinessIncomeSchoolAcademyClassesDto
    {
        public int Fk_BusinessIncomeChildAcademy { get; set; }
        public string ClassName { get; set; }
        public string NoOfStudents { get; set; }

        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
    }
}
