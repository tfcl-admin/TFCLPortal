using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TDSBusinessExpenses;

namespace TFCLPortal.TDSBusinessExpenses.Dto
{
    [AutoMapTo(typeof(TDSBusinessExpense))]
    public class CreateTDSBusinessExpenseDto
    {
        public int ApplicationId { get; set; }

        public string NetMonthlyBusinessExpense { get; set; }
        public List<CreateTDSBusinessExpenseChildDto> TDSBusinessExpenseChild { get; set; }
         
    }
}
