
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ContactPreferences;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ContactPreference))]
    public class ContactPreferencesListDto:Entity
    {
        public string Name { get; set; }
    }
}
