using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.Preferences.Dto
{
    [AutoMapTo(typeof(Preference))]
    public class EditPreferenceInput
    {
      
        public List<UpdatePreferenceDto> Preferences { get; set; }
    }
}
