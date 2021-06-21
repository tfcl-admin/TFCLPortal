using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BankAccountDetails.Dto
{

    [AutoMapTo(typeof(BankAccountDetail))]
    public class CreateBankAccountDto
    {
   
        public List<BankAccountDto> BankAccountDetails { get; set; }
        
    }
}
