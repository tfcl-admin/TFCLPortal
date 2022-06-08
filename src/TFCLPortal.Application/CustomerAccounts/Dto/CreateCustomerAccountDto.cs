using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CustomerAccounts.Dto
{
    [AutoMapTo(typeof(CustomerAccount))]
    public class CreateCustomerAccountDto
    {
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public bool isPhoneVerified { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isActive { get; set; }
    }
}
