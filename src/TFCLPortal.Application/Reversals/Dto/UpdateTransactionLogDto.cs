using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.TransactionLogs.Dto
{
   public class UpdateTransactionLogDto : CreateTransactionLogDto
    {
        public int Id { get; set; }
    }
}
