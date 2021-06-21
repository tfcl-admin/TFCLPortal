using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CoApplicantDetails.Dto
{
    [AutoMapTo(typeof(CoApplicantDetail))]
    public class EditCoApplicantDetailInput
    {
        public List<UpdateCoApplicantDto> updatecoapplicant { get; set; }

    }
}
