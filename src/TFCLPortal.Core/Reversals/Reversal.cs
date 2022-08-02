using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Reversals
{
    [Table("Reversal")]
    public class Reversal : FullAuditedEntity<Int32>
    {
        public int InitiatedBy { get; set; }
        public int TransactionId { get; set; }
        public int AuthorizedBy { get; set; }
        public string Details { get; set; }
        public bool? isAuthorized { get; set; }
    }
}
