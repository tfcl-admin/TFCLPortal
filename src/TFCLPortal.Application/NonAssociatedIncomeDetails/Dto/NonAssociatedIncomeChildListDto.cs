using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NonAssociatedIncomeChilds;

namespace TFCLPortal.NonAssociatedIncomeDetails.Dto
{
    [AutoMapFrom(typeof(NonAssociatedIncomeChild))]
    public class NonAssociatedIncomeChildListDto :Entity<int>
    {
        public int Fk_NonAssociatedIncome { get; set; }
        public int? OtherOccupation { get; set; }
        public string OtherOccupationName { get; set; }
        public string OtherOccupationOthers { get; set; }
        public int? SourceOfIncome { get; set; }
        public string SourceOfIncomeName { get; set; }
        public string SourceOfIncomeOthers { get; set; }
        public bool? DocumentProof { get; set; }
        public string ActualRevenue { get; set; }
        public string ConsideredPercentage { get; set; }
        public string ConsideredAmount { get; set; }
    }
}
