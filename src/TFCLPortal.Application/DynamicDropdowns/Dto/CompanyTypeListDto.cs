using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.CompanyTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(CompanyType))]
    public class CompanyTypeListDto : Entity
    {
        public string Name { get; set; }
    }
}
