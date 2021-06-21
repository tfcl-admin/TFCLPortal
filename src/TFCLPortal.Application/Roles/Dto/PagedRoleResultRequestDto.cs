using Abp.Application.Services.Dto;

namespace TFCLPortal.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

