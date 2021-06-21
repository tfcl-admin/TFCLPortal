using System.Threading.Tasks;
using Abp.Application.Services;
using TFCLPortal.Sessions.Dto;

namespace TFCLPortal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
