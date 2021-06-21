using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NonAssociatedIncomes;

namespace TFCLPortal.NonAssociatedIncomeDetails.Dto
{
    [AutoMapTo(typeof(NonAssociatedIncome))]

    public class CreateNonAssociatedIncomeDto
    {
        public int ApplicationId { get; set; }
        public string isNonAssociatedIncome { get; set; }
        public List<CreateNonAssociatedIncomeChildDto> NonAssociatedIncomeChilds { get; set; }
        public string TotalNonAssociatedIncome { get; set; }
    }
}
