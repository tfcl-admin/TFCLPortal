using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TDSBusinessExpenses.Dto
{
    [AutoMapFrom(typeof(TDSBusinessExpense))]
    public class TDSBusinessExpenseListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string NetMonthlyBusinessExpense { get; set; }
        public List<TDSBusinessExpenseChildListDto> TDSBusinessExpenseChild { get; set; }

    }
}
