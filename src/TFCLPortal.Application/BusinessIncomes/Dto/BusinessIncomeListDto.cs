using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapFrom(typeof(BusinessIncome))]
    public class BusinessIncomeListDto : Entity<int>
    {
        public int ApplicationId { get; set; }

        public string TotalFeeCollection { get; set; }
        public string AnyOtherIncome { get; set; }
        public string GrandTotalIncome { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string OtherSourceOfFund { get; set; }
        public string AllowedMinStudents { get; set; }

        //NEW
        public string nGrandTotalSchoolStudents { get; set; }
        public string nGrandTotalAcademyStudents { get; set; }
        public string nGrandTotalSchoolFeeIncome { get; set; }
        public string nGrandTotalAcademyFeeIncome { get; set; }
        public List<BusinessIncomeSchoolListDto> businessChildLists { get; set; }
    }
}
