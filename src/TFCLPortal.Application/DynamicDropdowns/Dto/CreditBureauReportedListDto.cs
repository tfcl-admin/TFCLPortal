using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.CreditBureauReporteds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(CreditBureauReported))]
    public class CreditBureauReportedListDto : Entity
    {
        public string Name { get; set; }
    }
}
