using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AppScreenStatuses.Dto;

namespace TFCLPortal.AppScreenStatuses
{
    public class AppScreenStatusAppService : TFCLPortalAppServiceBase, IAppScreenStatusAppService
    {
        private readonly IRepository<AppScreenStatus, Int32> _appScreenStatusRepository;
        private string appScreenStatus = "App Screen Status";
        public AppScreenStatusAppService(IRepository<AppScreenStatus, Int32> appScreenStatusRepository)
        {
            _appScreenStatusRepository = appScreenStatusRepository;
        }

        public async Task CreateAppScreenStatus(CreateAppScreenStatusDto input)
        {
            try
            {
                var appScreenStats = ObjectMapper.Map<AppScreenStatus>(input);
                await _appScreenStatusRepository.InsertAsync(appScreenStats);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", appScreenStatus));
            }
        }

        public async Task<AppScreenStatusListDto> GetAppScreenStatusById(int Id)
        {
            try
            {
                var appScreenStats = await _appScreenStatusRepository.GetAsync(Id);

                return ObjectMapper.Map<AppScreenStatusListDto>(appScreenStats);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", appScreenStatus));
            }
        }

        public async Task<string> UpdateAppScreenStatus(UpdateAppScreenStatusDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var appScreenStats = _appScreenStatusRepository.Get(input.Id);
                if (appScreenStats != null && appScreenStats.Id > 0)
                {
                    ObjectMapper.Map(input, appScreenStats);
                    await _appScreenStatusRepository.UpdateAsync(appScreenStats);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", appScreenStatus));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", appScreenStatus));
            }
        }
    }
}
