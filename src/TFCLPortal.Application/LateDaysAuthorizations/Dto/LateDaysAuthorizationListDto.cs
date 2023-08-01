using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.LateDaysAuthorizations.Dto
{
   [ AutoMapFrom(typeof(LateDaysAuthorization))]
   public class LateDaysAuthorizationListDto : Entity<int>
    {
 
        public int ApplicationId { get; set; }
 
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }

        public int LateDays { get; set; }
        public decimal TotalPunishment { get; set; }

        public bool? isAuthorized { get; set; }
 

        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string CNIC { get; set; }
        public string Branch { get; set; }
    }
}
