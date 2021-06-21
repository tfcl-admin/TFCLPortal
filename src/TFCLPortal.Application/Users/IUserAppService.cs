using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TFCLPortal.Roles.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {//tyest
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
        Task<UserDto> GetUserById(long Id);

        List<UserDto> GetAllUsers();

        Task<string> UpdateFcmTokenAsync(long Id,string Token);

    }
}
