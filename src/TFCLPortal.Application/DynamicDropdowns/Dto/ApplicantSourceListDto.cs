using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.ApplicantSources;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ApplicantSource))]
    public class ApplicantSourceListDto : Entity
    {
        public string Name { get; set; }
    }
}
