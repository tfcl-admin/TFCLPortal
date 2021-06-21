using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Preferences.Dto;

namespace TFCLPortal.Preferences
{
   public interface IPreferenceAppService: IApplicationService
    {
        Task<string> Create(CreatePreferenceInput createPreferenceInput, int applicationId);
        Task<string> Update(EditPreferenceInput editPreferenceInput);
        Task<List<PreferencesListDto>> GetPreferencesById(int Id);
        Task<List<PreferencesListDto>> GetPreferencesByApplicationId(int ApplicationId);
        bool CheckPreferencesByApplicationId(int ApplicationId);
    }
}
