using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Targets.Dto
{
    [AutoMapFrom(typeof(Target))]
    public class TargetListDto : EntityDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_SdeId { get; set; }
        public string SdeName { get; set; }
        public int Fk_BranchId { get; set; }
        public string BranchName { get; set; }
        public int Fk_ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public int NoOfApplications { get; set; }
        public int DisbursmentValue { get; set; }
        public decimal Yeild { get; set; }
        public decimal SecuredUnsecuredRatio { get; set; }
        public int RepeatClients { get; set; }
        public int Maturity { get; set; }
    }
}
