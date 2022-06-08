using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CoApplicantDetails;

namespace TFCLPortal.DeceasedAuthorizations.Dto
{
    [AutoMapTo(typeof(DeceasedAuthorization))]
    public class EditDeceasedAuthorization : CreateDeceasedAuthorization
    {
        public int Id { get; set; }
    }
}
