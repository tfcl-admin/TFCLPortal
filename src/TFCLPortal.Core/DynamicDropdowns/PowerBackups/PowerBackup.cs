﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.PowerBackups
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("PowerBackup")]
    public class PowerBackup : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
