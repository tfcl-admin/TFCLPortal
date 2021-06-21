using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DependentEducationDetails.Dto
{
    [AutoMapFrom(typeof(DependentEducationDetail))]
    public class DependentEducationDetailListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public bool? isDependentEducation { get; set; }
        public string TotalMonthlyFee { get; set; }
        public List<DependentEducationDetailChildListDto> dependentEducationDetailChild { get; set; }
    }
}
