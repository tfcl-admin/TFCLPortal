using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.Transactions.Dto
{
   public class UpdateTransactionDto : CreateTransactionDto
    {
        public int Id { get; set; }
    }
}
