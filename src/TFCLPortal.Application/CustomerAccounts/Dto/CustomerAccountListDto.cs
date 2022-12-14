using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Transactions;
using TFCLPortal.Transactions.Dto;

namespace TFCLPortal.CustomerAccounts.Dto
{
    [AutoMapFrom(typeof(CustomerAccount))]
    public class CustomerAccountListDto : FullAuditedEntityDto
    {
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ClientId { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public bool isPhoneVerified { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isActive { get; set; }

        public List<TransactionListDto> transactions { get; set; }
    }
}
