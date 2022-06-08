using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.EnhancementRequests.Dto
{
    [AutoMapTo(typeof(EnhancementRequest))]
    public class CreateEnhancementRequestDto
    {

        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
        public int RequestState { get; set; }
      
        //0-> Requested
        //1-> Authorized
        //2-> Rejected
        //3-> Migrated

    }
}
