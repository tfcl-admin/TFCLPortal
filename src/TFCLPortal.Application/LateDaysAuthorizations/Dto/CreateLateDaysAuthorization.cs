using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.LateDaysAuthorizations;

namespace TFCLPortal.LateDaysAuthorizations.Dto
{
    [AutoMapTo(typeof(LateDaysAuthorization))]
    public  class CreateLateDaysAuthorization
    {
        public int ApplicationId { get; set; }
        public int LateDays { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
        public decimal TotalPunishment { get; set; }
        public bool? isAuthorized { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string SchoolName { get; set; }
        public int branchId { get; set; }
    }
}
