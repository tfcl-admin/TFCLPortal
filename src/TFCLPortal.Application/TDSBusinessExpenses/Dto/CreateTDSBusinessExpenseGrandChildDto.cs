using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TDSBusinessExpenses;

namespace TFCLPortal.TDSBusinessExpenses.Dto
{
    [AutoMapTo(typeof(TDSBusinessExpenseGrandChild))]
    public class CreateTDSBusinessExpenseGrandChildDto
    {
        public int Fk_TDSBusinessExpenseChildid { get; set; }
        public string EmployerName { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }

    }
}
