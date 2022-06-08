using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.EnhancementRequests.Dto
{
    [AutoMapFrom(typeof(EnhancementRequest))]
    public class EnhancementRequestListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
        public int RequestState { get; set; }

        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientBusiness { get; set; }

        public int OldApplicationId { get; set; }


    }
}
