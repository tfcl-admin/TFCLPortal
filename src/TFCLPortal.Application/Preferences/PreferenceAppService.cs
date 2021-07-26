using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.DynamicDropdowns.RelationshipWithApplicants;
using TFCLPortal.Preferences.Dto;

namespace TFCLPortal.Preferences
{
    public class PreferenceAppService : TFCLPortalAppServiceBase, IPreferenceAppService
    {
        #region Properties
        private readonly IRepository<Preference> _preferenceRepository;
        private readonly IRepository<RelationshipWithApplicant> _relationshipWithApplicantRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        #endregion
        #region Constructor 
        public PreferenceAppService(IRepository<Preference> preferenceRepository, IApplicationAppService applicationAppService, IRepository<RelationshipWithApplicant> relationshipWithApplicantRepository,IApiCallLogAppService apiCallLogAppService)
        {
            _preferenceRepository = preferenceRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
            _relationshipWithApplicantRepository = relationshipWithApplicantRepository;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreatePreferenceInput createPreferenceInput, int applicationId)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreatePreference";
                callLog.Input = JsonConvert.SerializeObject(createPreferenceInput);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);


                if (applicationId == 0 && createPreferenceInput.Preferences.Count > 0)
                {
                    applicationId = createPreferenceInput.Preferences[0].ApplicationId;
                }

                var IsExist = _preferenceRepository.GetAllList().Where(x => x.ApplicationId == applicationId).ToList();
                if (IsExist.Count > 0)
                {
                    foreach (var coApplicnt in IsExist)
                    {
                        var coapplicant = ObjectMapper.Map<Preference>(coApplicnt);
                        await _preferenceRepository.DeleteAsync(coapplicant);
                        CurrentUnitOfWork.SaveChanges();
                    }
                    foreach (PreferenceAddDto preference in createPreferenceInput.Preferences)
                    {
                        //preference.ApplicationId = applicationId;
                        var personalDetail = ObjectMapper.Map<Preference>(preference);
                        await _preferenceRepository.InsertAsync(personalDetail);
                    }
                }
                else
                {
                    foreach (PreferenceAddDto preference in createPreferenceInput.Preferences)
                    {
                        //preference.ApplicationId = applicationId;
                        var personalDetail = ObjectMapper.Map<Preference>(preference);
                        await _preferenceRepository.InsertAsync(personalDetail);
                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Reference Detail", applicationId);

            }

            catch (Exception)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Preferences"));
            }
            return "Success";
        }

        public async Task<List<PreferencesListDto>> GetPreferencesByApplicationId(int ApplicationId)
        {
            try
            {

                var bankAccountDetailsList = _preferenceRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                var preferenceDetailMapped = ObjectMapper.Map<List<PreferencesListDto>>(bankAccountDetailsList);

                if (preferenceDetailMapped.Count > 0)
                {
                    foreach (var preference in preferenceDetailMapped)
                    {
                        if (preference.RelationshipWithApplicant != 0 && preference.RelationshipWithApplicant != null)
                        {
                            var result = _relationshipWithApplicantRepository.Get((int)preference.RelationshipWithApplicant);
                            preference.RelationshipWithApplicantName = result.Name;
                        }
                    }
                }

                return preferenceDetailMapped;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Preferences"));
            }
        }

        public bool CheckPreferencesByApplicationId(int ApplicationId)
        {
            try
            {
                var preferenceDetail = _preferenceRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                if (preferenceDetail.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Preferences"));
            }
        }

        public async Task<string> Update(EditPreferenceInput editPreferenceInput)
        {
           

            string ResponseString = "";
            try
            {

                foreach (UpdatePreferenceDto preferenceDto in editPreferenceInput.Preferences)
                {
                    var preferenceobj = _preferenceRepository.Get(preferenceDto.Id);
                    if (preferenceobj != null && preferenceobj.Id > 0)
                    {


                        ObjectMapper.Map(preferenceDto, preferenceobj);

                        await _preferenceRepository.UpdateAsync(preferenceobj);

                        CurrentUnitOfWork.SaveChanges();
                        ResponseString = "Records Updated Successfully";
                    }
                    else
                    {
                        throw new UserFriendlyException(L("UpdateMethodError{0}", "Preferences"));

                    }
                }

                return ResponseString;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Preferences"));
            }
        }

        public async Task<List<PreferencesListDto>> GetPreferencesById(int Id)
        {
            try
            {

                var preferenceDetailsList = await _preferenceRepository.GetAllListAsync(x => x.Id == Id);

                return ObjectMapper.Map<List<PreferencesListDto>>(preferenceDetailsList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Preferences"));
            }
        }
        #endregion
    }
}
