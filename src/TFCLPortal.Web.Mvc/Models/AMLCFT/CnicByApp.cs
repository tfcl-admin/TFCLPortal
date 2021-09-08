using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.AMLCFT
{
    public class CnicByApp
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string BusinessName { get; set; }
        public string ClientCNIC { get; set; }
        
        public string Guarantor1Cnic { get; set; }
        public string Guarantor1Name { get; set; }

        public string Guarantor2Cnic { get; set; }
        public string Guarantor2Name { get; set; }

        public string CoApplicant1Cnic { get; set; }
        public string CoApplicant1Name { get; set; }

        public string CoApplicant2Cnic { get; set; }
        public string CoApplicant2Name { get; set; }

        public string Screenstatus { get; set; }
    }
}
