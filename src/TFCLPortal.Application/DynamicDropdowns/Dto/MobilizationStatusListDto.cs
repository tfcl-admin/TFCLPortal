using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(MobilizationStatus))]
    public class MobilizationStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
