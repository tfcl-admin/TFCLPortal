using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchoolClasses;

namespace TFCLPortal.BusinessExpenses.Dto
{
    [AutoMapFrom(typeof(BusinessExpenseSchoolClass))]
    public class BusinessExpenseSchoolClassesListDto : EntityDto
    {
        public int Fk_BusinessExpenseSchool { get; set; }
        public string ClassNameOrSubject { get; set; }
        public int? Designation { get; set; }
        public string DesignationName { get; set; }
        public int? Gender { get; set; }
        public string GenderName { get; set; }
        public string Salary { get; set; }

    }
}
