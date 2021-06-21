using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.Banks;
using TFCLPortal.DynamicDropdowns.AgeOfVehicles;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(AgeOfVehicle))]
    public class AgeOfVehicleListDto : Entity
    {
        public string Name { get; set; }
        //public string AllowedLTV { get; set; }
    }
}
