using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.OtherDetails.Dto
{
    [AutoMapFrom(typeof(OtherDetail))]
    public class OtherDetailListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string OtherNationality { get; set; }
        public string NTNNumber { get; set; }
        public string MotherMaidenName { get; set; }
        public int OtherOccupation { get; set; }
        public int OtherSourceOfFund { get; set; }
        public string OtherSourceOfFundDD { get; set; }
        public string OtherOccupationDD { get; set; }
        public long Amount { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string FundSourceName { get; set; }
        public string OccupationName { get; set; }
    }
}
