using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.PostDisbursementForms.Dto
{
    [AutoMapFrom(typeof(PostDisbursementForm))]
    public class PostDisbursementFormListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string FileMonthlyIncome { get; set; }
        public string FileNetBusinessIncome { get; set; }
        public string FileIncomeAfterHHexp { get; set; }
        public string FileCollateral { get; set; }
        public string GuarantorBusinessCondition { get; set; }
        public string Comments { get; set; }
        public string LoanAmountUtilization { get; set; }
        public string CurrentMonthlyIncome { get; set; }
        public string CurrentNetBusinessIncome { get; set; }
        public string CurrentIncomeAfterHHexp { get; set; }
        public string CurrentCollateral { get; set; }

    }
}
