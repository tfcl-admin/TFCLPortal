using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TFCLPortal.MultiTenancy;

namespace TFCLPortal.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
