
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ContactSources;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(ContactSource))]
    public class CreateContactSourceDto
    {
        public string Name { get; set; }
    }
}
