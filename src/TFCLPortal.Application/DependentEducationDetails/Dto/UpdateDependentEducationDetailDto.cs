using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DependentEducationDetails.Dto
{
    [AutoMapTo(typeof(DependentEducationDetail))]
    public class UpdateDependentEducationDetailDto : CreateDependentEducationDetailDto
    {
        public int Id { get; set; }
    }
}
