using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CoApplicantDetails.Dto
{
    [AutoMapTo(typeof(CoApplicantDetail))]
    public class CreateCoApplicantDetailInput  :Entity<int>
    {
       
        public List<CoApplicantAddDto> createCoApplicantDetailInput { get; set; }
        
    }
}
