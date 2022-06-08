using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CustomerAccounts.Dto
{
    public class UpdateCustomerAccountDto: CreateCustomerAccountDto
    {
        public int Id { get; set; }
    }
}
