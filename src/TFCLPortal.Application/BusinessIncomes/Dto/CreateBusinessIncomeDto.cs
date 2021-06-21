using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using System.Text;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncome))]
    public class CreateBusinessIncomeDto
    {
        public int ApplicationId { get; set; }
        
        public string TotalFeeCollection { get; set; }
        public string AnyOtherIncome { get; set; }
        public string GrandTotalIncome { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string OtherSourceOfFund { get; set; }

        //NEW
        public string nGrandTotalSchoolStudents { get; set; }
        public string nGrandTotalAcademyStudents { get; set; }
        public string nGrandTotalSchoolFeeIncome { get; set; }
        public string nGrandTotalAcademyFeeIncome { get; set; }
        public List<CreateBusinessIncomeSchoolDto> businessChildLists { get; set; }
    }
}
