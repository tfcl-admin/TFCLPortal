using Abp.AutoMapper;
using TFCLPortal.DynamicDropdowns.RespondantDesignations;
using Abp.Domain.Entities;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(RespondantDesignation))]
    public class RespondantDesignationListDto : Entity
    {
        public string Name { get; set; }
    }


}
