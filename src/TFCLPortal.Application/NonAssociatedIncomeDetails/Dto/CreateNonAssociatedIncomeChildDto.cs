using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NonAssociatedIncomeChilds;

namespace TFCLPortal.NonAssociatedIncomeDetails.Dto
{
    [AutoMapTo(typeof(NonAssociatedIncomeChild))]
    public class CreateNonAssociatedIncomeChildDto 
    {
        public int Fk_NonAssociatedIncome { get; set; }
        public int? OtherOccupation { get; set; }
        public string OtherOccupationOthers { get; set; }
        public int? SourceOfIncome { get; set; }
        public string SourceOfIncomeOthers { get; set; }
        public bool? DocumentProof { get; set; }
        public string ActualRevenue { get; set; }
        public string ConsideredPercentage { get; set; }
        public string ConsideredAmount { get; set; }
    }
}
