using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Holidays.Dto
{
    [AutoMapFrom(typeof(Holiday))]
    public class HolidayListDto : EntityDto
    {
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }
    }
}
