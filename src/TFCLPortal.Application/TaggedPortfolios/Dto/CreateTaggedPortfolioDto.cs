using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaggedPortfolios.Dto
{
    [AutoMapTo(typeof(TaggedPortfolio))]
    public class CreateTaggedPortfolioDto
    {
        public int ApplicationId { get; set; }
        public int OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string Comments { get; set; }
    }
}
