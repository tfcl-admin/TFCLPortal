using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchoolAcademies;
using TFCLPortal.BusinessExpenseSchoolClasses;

namespace TFCLPortal.BusinessExpenses.Dto
{
    [AutoMapFrom(typeof(BusinessExpenseSchoolAcademy))]
    public class BusinessExpenseSchoolAcademiesListDto : EntityDto
    {
        public int Fk_BusinessExpenseSchool { get; set; }
        public string AcademyName { get; set; }
        public string TeacherSalary { get; set; }
        public string OtherSalary { get; set; }
        public string RentAmount { get; set; }
        public string Utilities { get; set; }
        public string Entertainment { get; set; }
        public string RepairAndMaintenance { get; set; }
        public string Transportation { get; set; }
        public string Stationary { get; set; }
        public string RoyaltyFee { get; set; }
        public string Committee { get; set; }
        public string InternetCharges { get; set; }
        public string OtherExpenses { get; set; }
        public string TotalMonthlyExpenses { get; set; }
        public string ProvisionOfExpenses { get; set; }
        public string MonthlyBusinessExpenses { get; set; }

        public string AdditionalFieldLabel1 { get; set; }
        public string AdditionalFieldValue1 { get; set; }
        public string AdditionalFieldLabel2 { get; set; }
        public string AdditionalFieldValue2 { get; set; }
        public string AdditionalFieldLabel3 { get; set; }
        public string AdditionalFieldValue3 { get; set; }

        public List<BusinessExpenseSchoolAcademyClassesListDto> businessExpenseSchoolAcademyClasses { get; set; }


    }
}
