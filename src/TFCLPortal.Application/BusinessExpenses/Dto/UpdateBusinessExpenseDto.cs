using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessExpenses.Dto
{
    public class UpdateBusinessExpenseDto : CreateBusinessExpenseDto
    {
        public int Id { get; set; }
    }
}
