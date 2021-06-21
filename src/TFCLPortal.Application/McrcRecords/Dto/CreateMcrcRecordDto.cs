using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.McrcRecords;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.McrcRecords.Dto
{
    [AutoMapTo(typeof(McrcRecord))]
    public  class CreateMcrcRecordDto
    {
        public int ApplicationId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public int User3Id { get; set; }
        public int User4Id { get; set; }
        public int User5Id { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
