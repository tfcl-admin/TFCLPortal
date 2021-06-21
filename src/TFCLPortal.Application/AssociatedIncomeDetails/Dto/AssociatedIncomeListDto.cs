using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssociatedIncomes;

namespace TFCLPortal.AssociatedIncomeDetails.Dto
{
    [AutoMapFrom(typeof(AssociatedIncome))]
    public class AssociatedIncomeListDto : Entity 
    {
        public int ApplicationId { get; set; }
        public string isAssociatedIncome { get; set; }
        public List<AssociatedIncomeChildListDto> AssociatedIncomeChilds { get; set; }
        public string GrandTotalAssociatedIncome { get; set; }
    }
}
