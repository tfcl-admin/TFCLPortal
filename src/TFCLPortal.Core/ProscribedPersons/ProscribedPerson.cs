using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ProscribedPersons
{
    [Table("ProscribedPersons")]
  public class ProscribedPerson: FullAuditedEntity<int>
    {
        public string name { get; set; }        
        public string fatherName { get; set; }
        public string cnic { get; set; }
        public string province { get; set; }
        public string district { get; set; }  
    }
}
