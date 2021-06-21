
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BccDecisions.Dto
{
    [AutoMapTo(typeof(BccDecision))]
    public class CreateBccDecisionDto
    {
        public int ApplicationId { get; set; }
        public string BccId { get; set; }
        public int BccMember1UserId { get; set; }
        public string BccMember1Recommendation { get; set; }
        public string BccMember1Reason { get; set; }
        public int BccMember2UserId { get; set; }
        public string BccMember2Recommendation { get; set; }
        public string BccMember2Reason { get; set; }
        public int BccMember3UserId { get; set; }
        public string BccMember3Recommendation { get; set; }
        public string BccMember3Reason { get; set; }
        public string Decision { get; set; }
        public string Reason { get; set; }
        public string LoanAmount { get; set; }
        public string LoanTenure { get; set; }
        public string GraceDays { get; set; }
        public string AppliedMarkup { get; set; }
        public string CollateralAmount { get; set; }
        public string LTV { get; set; }
        public string CollateralEvaluation { get; set; }
        public string isDeferment { get; set; }
        public string DefermentPeriod { get; set; }
        public string isTranches { get; set; }
        public string TranchesDates { get; set; }
        public string TranchesAmount { get; set; }
        public string CheckName { get; set; }
        public IFormFile file { get; set; }
        public string DecisionFile { get; set; }
        public string Comments { get; set; }
    }
}
