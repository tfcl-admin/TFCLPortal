using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Branches.Dto
{
    [AutoMapTo(typeof(Branch))]
    public class CreateBranchDetail
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public string Active { get; set; }
        public string Address { get; set; }
        public int FK_companyid { get; set; }
    }
}
