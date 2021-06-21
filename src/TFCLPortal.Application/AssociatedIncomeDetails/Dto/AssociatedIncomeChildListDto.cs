using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssociatedIncomeChilds;
using TFCLPortal.AssociatedIncomeGrandChilds;

namespace TFCLPortal.AssociatedIncomeDetails.Dto
{
    [AutoMapFrom(typeof(AssociatedIncomeChild))]
    public class AssociatedIncomeChildListDto : Entity
    {
        public int Fk_AssociatedIncome { get; set; }
        public string isAssociatedIncome { get; set; }
        public string BranchName { get; set; }
        public string TotalAssociatedIncome { get; set; }
        public List<AssociatedIncomeGrandChildListDto> associatedIncomeGrandChilds { get; set; }
}
}
