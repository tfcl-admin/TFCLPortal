
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessIncomeSchools;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncomeSchool))]
    public class CreateBusinessIncomeSchoolDto 
    {
        public int Fk_BusinessIncome { get; set; }
        public string SchoolName { get; set; }
        public List<CreateBusinessIncomeSchoolClassesDto> BusinessIncomeSchoolClasses { get; set; }
        public string TotalStudentsMale { get; set; }
        public string TotalStudentsFemale { get; set; }
        public string TotalStudentsTotal { get; set; }
        public string TotalAvgFee { get; set; }
        public string totalFeeCollection { get; set; }
        public string CollectionEfficiency { get; set; }
        public string GenderBalance { get; set; }
        public string ActualStudents { get; set; }
        public string StudentsConsidered { get; set; }
        public string StudentsDifference { get; set; }
        public string ReasonForDifference { get; set; }
        public string StudentTeacherRatio { get; set; }
        public string StudentClassroomRatio { get; set; }
        public string ConsideredSchoolFee { get; set; }
        public List<CreateBusinessIncomeSchoolAcademyDto> BusinessIncomeSchoolAcademies { get; set; }

    }
}

