using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssociatedIncomes;

namespace TFCLPortal.AssociatedIncomeDetails.Dto
{
    [AutoMapTo(typeof(AssociatedIncome))]

    public class CreateAssociatedIncomeDto
    {
        public int ApplicationId { get; set; }
        public string isAssociatedIncome { get; set; }
        public List<CreateAssociatedIncomeChildDto> AssociatedIncomeChilds { get; set; }
        public string GrandTotalAssociatedIncome { get; set; }
    }
}
