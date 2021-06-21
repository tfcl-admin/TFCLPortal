﻿using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.AssociatedIncomeGrandChilds;

namespace TFCLPortal.AssociatedIncomeDetails.Dto
{
    [AutoMapFrom(typeof(AssociatedIncomeGrandChild))]
    public class AssociatedIncomeGrandChildListDto : Entity
    {
        public int Fk_AssociatedIncomeChild { get; set; }
        public int? OtherAssociatedIncome { get; set; }
        public string OtherAssociatedIncomeName { get; set; }
        public string OtherAssociatedIncomeOthers { get; set; }
        public bool? DocumentProof { get; set; }
        public string NumberOfStudents { get; set; }
        public string AvgCharges { get; set; }
        public string YearlyRevenue { get; set; }
        public string MonthlyRevenue { get; set; }
        public string ProfitMargin { get; set; }
        public string OtherAssociatedIncomeAmount { get; set; }
        public string ConsideredPercentage { get; set; }
        public string ConsideredAmount { get; set; }
    }
}