using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.AcademicSessions;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(AcademicSession))]
    public class AcademicSessionListDto : Entity
    {
        public string Name { get; set; }
    }
}
