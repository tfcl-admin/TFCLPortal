using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.BccDecisions.Dto
{
    [AutoMapFrom(typeof(BccDecision))]
    public class BccDecisionListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public string BccId { get; set; }
        public string ApplicantName { get; set; }
        public string SchoolName { get; set; }
        public string CNIC { get; set; }
        public string ClientId { get; set; }
        public int BccMember1UserId { get; set; }
        public string BccMember1UserName { get; set; }
        public string BccMember2UserName { get; set; }
        public string BccMember3UserName { get; set; }
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
        public string Comments { get; set; }
        public string DecisionFile { get; set; }
        
    }
}
