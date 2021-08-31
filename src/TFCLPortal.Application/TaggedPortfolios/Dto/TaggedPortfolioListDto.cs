﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.TaggedPortfolios.Dto
{
    [AutoMapFrom(typeof(TaggedPortfolio))]
    public class TaggedPortfolioListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string Comments { get; set; }
    }
}
