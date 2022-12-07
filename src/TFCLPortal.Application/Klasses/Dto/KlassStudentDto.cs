using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Klasses.Dto
{
    [AutoMapTo(typeof(Klass))]
    public class CreateKlassDto
    {
 
        public string Name { get; set; }
        public int TotalStudents { get; set; }
    }
}
