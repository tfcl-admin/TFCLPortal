using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.BusinessIncomeAcademyClasses;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapFrom(typeof(BusinessIncomeSchoolAcademyClass))]
    public class BusinessIncomeSchoolAcademyClassesListDto : Entity<int>
    {
        public int Fk_BusinessIncomeChildAcademy { get; set; }
        public string ClassName { get; set; }
        public string NoOfStudents { get; set; }

        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
    }
}
