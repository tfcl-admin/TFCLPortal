using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DependentEducationDetails.Dto
{
    [AutoMapTo(typeof(DependentEducationDetail))]
    public class CreateDependentEducationDetailDto 
    {
        public int ApplicationId { get; set; }
        public bool? isDependentEducation { get; set; }
        public string TotalMonthlyFee { get; set; }
        public List<CreateDependentEducationDetailChildDto> dependentEducationDetailChild { get; set; }

    }
}
