using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.Company
{
    public class CreateCompanyModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal GST { get; set; }
        public string NTN { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Active { get; set; }
    }
}
