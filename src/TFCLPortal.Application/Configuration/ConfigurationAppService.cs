using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TFCLPortal.Configuration.Dto;

namespace TFCLPortal.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TFCLPortalAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
