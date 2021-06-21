using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(NatureOfEmployment))]
    public class NatureOfEmploymentListDto : Entity
    {
        public string Name { get; set; }
    }
}
