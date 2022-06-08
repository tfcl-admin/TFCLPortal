using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.Common
{
    public class TargetIndexModel
    {
        public List<Targets.Dto.TargetListDto> Targets { get; set; }
        public TargetIndexModelFilter Filters { get; set; }
        public int? Fk_SdeId { get; set; }
        public int? Fk_ProductTypeId { get; set; }
        public int? Fk_BranchId { get; set; }
    }

    public class TargetIndexModelFilter
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? Fk_SdeId { get; set; }
        public int? Fk_ProductTypeId { get; set; }
        public int? Fk_BranchId { get; set; }
    }
}
