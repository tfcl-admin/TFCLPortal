using System.Threading.Tasks;
using TFCLPortal.Configuration.Dto;

namespace TFCLPortal.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
