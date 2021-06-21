using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Companies.Dto
{
    [AutoMapFrom(typeof(Company))]
    public class CompanyDetailListDto : EntityDto
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
