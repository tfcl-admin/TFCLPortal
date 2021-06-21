using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ApplicationWiseDeviationVariables.Dto
{
    public class GetMarkupParameters
    {
        public string LoanAmount { get; set; }
        public string LoanTenure { get; set; }
        public string NoOfInstallments { get; set; }
        public string ProductId { get; set; }
        public int ApplicationId { get; set; }
        public string Security { get; set; }

    }
}
