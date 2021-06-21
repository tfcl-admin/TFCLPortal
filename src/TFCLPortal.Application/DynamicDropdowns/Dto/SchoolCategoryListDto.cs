using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.SchoolCategories;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(SchoolCategory))]
    public class SchoolCategoryListDto : Entity
    {
        public string Name { get; set; }
    }
}
