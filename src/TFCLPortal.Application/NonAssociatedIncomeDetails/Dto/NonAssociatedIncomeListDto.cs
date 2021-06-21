using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NonAssociatedIncomes;

namespace TFCLPortal.NonAssociatedIncomeDetails.Dto
{
    [AutoMapFrom(typeof(NonAssociatedIncome))]
    public class NonAssociatedIncomeListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public string isNonAssociatedIncome { get; set; }
        public List<NonAssociatedIncomeChildListDto> NonAssociatedIncomeChilds { get; set; }
        public string TotalNonAssociatedIncome { get; set; }
    }
}
