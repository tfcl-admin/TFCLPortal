using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.McrcDecisions.Dto
{
    [AutoMapFrom(typeof(McrcDecision))]
    public class McrcDecisionListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public string McrcId { get; set; }
        public string ApplicantName { get; set; }
        public string SchoolName { get; set; }
        public string CNIC { get; set; }
        public string ClientId { get; set; }
        public int McrcMember1UserId { get; set; }
        public string McrcMember1UserName { get; set; }
        public string McrcMember2UserName { get; set; }
        public string McrcMember3UserName { get; set; }
        public string McrcMember4UserName { get; set; }
        public string McrcMember5UserName { get; set; }
        public string McrcMember1Recommendation { get; set; }
        public string McrcMember1Reason { get; set; }
        public int McrcMember2UserId { get; set; }
        public string McrcMember2Recommendation { get; set; }
        public string McrcMember2Reason { get; set; }
        public int McrcMember3UserId { get; set; }
        public string McrcMember3Recommendation { get; set; }
        public string McrcMember3Reason { get; set; }

        public int McrcMember4UserId { get; set; }
        public string McrcMember4Recommendation { get; set; }
        public string McrcMember4Reason { get; set; }
        public int McrcMember5UserId { get; set; }
        public string McrcMember5Recommendation { get; set; }
        public string McrcMember5Reason { get; set; }
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

        public bool isApplied { get; set; }

    }
}
