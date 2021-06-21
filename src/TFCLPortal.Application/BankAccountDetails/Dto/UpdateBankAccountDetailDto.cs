using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BankAccountDetails.Dto
{
   
    public class UpdateBankAccountDetailDto 
    {
        public List<BankAccountListDto> bankAccountLists { get; set; }
       
    }
}
