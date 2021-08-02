using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.McModels
{
    public class McModel
    {
        public List<TFCLPortal.Applications.Applicationz> applications { get; set; }
        public List<TFCLPortal.ManagmentCommitteeDecisions.Dto.ManagmentCommitteeDecisionListDto> decisions { get; set; }
    }
}
