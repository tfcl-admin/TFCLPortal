using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Companies.Dto
{
    [AutoMapTo(typeof(Company))]
    public class CreateCompanyDetailDto
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
