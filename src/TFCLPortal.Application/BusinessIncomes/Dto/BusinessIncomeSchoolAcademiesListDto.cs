using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System.Collections.Generic;
using TFCLPortal.BusinessIncomeSchoolAcademies;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapFrom(typeof(BusinessIncomeSchoolAcademy))]
    public class BusinessIncomeSchoolAcademiesListDto : Entity<int>
    {
        public int Fk_BusinessIncomeChild { get; set; }
        public string AcademyName { get; set; }
        public List<BusinessIncomeSchoolAcademyClassesListDto> BusinessIncomeSchoolAcademyClasses { get; set; }
        public string TotalFeeCalculation { get; set; }
        public string CollectionEfficiency { get; set; }
        public string ConsideredAcademyFee { get; set; }
        public string ActualStudents { get; set; }
        public string ConsideredStudents { get; set; }
        public string StudentDifference { get; set; }
        public string ReasonForDifference { get; set; }

        public string classesTotalStudents { get; set; }
        public string classesTotalAvgFee { get; set; }

    }
}
