using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Reversals.Dto
{
    [AutoMapTo(typeof(Reversal))]
    public class CreateReversalDto
    {
        public int InitiatedBy { get; set; }
        public int TransactionId { get; set; }
        public int AuthorizedBy { get; set; }
        public string Details { get; set; }
        public bool? isAuthorized { get; set; }
    }
}
