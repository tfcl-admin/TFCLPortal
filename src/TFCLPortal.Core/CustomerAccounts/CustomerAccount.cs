using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CustomerAccounts
{
    [Table("CustomerAccount")]
    public  class CustomerAccount : FullAuditedEntity<int>
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
