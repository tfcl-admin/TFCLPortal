using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.Branches.Dto
{
    [AutoMapFrom(typeof(Branch))]
    public class BranchDetailList : EntityDto
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public string Active { get; set; }
        public string Address { get; set; }
        public int FK_companyid { get; set; }
        public int FK_BMid { get; set; }

        public CompanyDetailListDto Comapny { get; set; }
    }
}
