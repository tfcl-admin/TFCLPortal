using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssociatedIncomeChilds;

namespace TFCLPortal.AssociatedIncomeDetails.Dto
{
    [AutoMapTo(typeof(AssociatedIncomeChild))]
    public class CreateAssociatedIncomeChildDto
    {
        public int Fk_AssociatedIncome { get; set; }
        public string isAssociatedIncome { get; set; }
        public string BranchName { get; set; }
        public string TotalAssociatedIncome { get; set; }
        public List<CreateAssociatedIncomeGrandChildDto> associatedIncomeGrandChilds { get; set; }
    }
}
