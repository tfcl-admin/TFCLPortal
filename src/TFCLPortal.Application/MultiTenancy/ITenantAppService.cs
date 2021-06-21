using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TFCLPortal.MultiTenancy.Dto;

namespace TFCLPortal.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

