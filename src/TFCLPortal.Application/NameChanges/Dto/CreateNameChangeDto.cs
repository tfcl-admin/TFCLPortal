using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.NameChanges.Dto
{
    [AutoMapTo(typeof(NameChange))]
    public class CreateNameChangeDto
    {
        public int ApplicationId { get; set; }
        public string OldClientName { get; set; }
        public string NewClientName { get; set; }
        public string OldBusinessName { get; set; }
        public string NewBusinessName { get; set; }
    }
}
