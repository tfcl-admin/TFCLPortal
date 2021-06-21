using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Preferences.Dto
{
    [AutoMapTo(typeof(Preference))]
    public class CreatePreferenceInput
    {
        
        public List<PreferenceAddDto> Preferences { get; set; }
        
    }
}
