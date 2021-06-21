using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.BADataChecks.Dto;
using TFCLPortal.NotificationLogs;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BADataChecks
{
    public class BADataCheckAppService : TFCLPortalAppServiceBase, IBADataCheckAppService
    {
        private readonly IRepository<BADataCheck, Int32> _BADataCheckRepository;
        private readonly INotificationLogAppService _notificationLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private string baDataChecks = "BA Data Check";
        public BADataCheckAppService(IRepository<BADataCheck, Int32> BADataCheckRepository, IApplicationAppService applicationAppService, INotificationLogAppService notificationLogAppService)
        {
            _BADataCheckRepository = BADataCheckRepository;
            _notificationLogAppService = notificationLogAppService;
            _applicationAppService = applicationAppService;
        }
        public async Task<string> CreateBADocumentUpload(CreateBADataCheckDto Input)
        {
            try
            {
                var baDataCheck = ObjectMapper.Map<BADataCheck>(Input);
                await _BADataCheckRepository.InsertAsync(baDataCheck);
                CurrentUnitOfWork.SaveChanges();

                var appData = _applicationAppService.GetApplicationById(Input.ApplicationId);
                if (appData != null)
                {
                    await _notificationLogAppService.SendNotification((int)appData.CreatorUserId, Input.DocumentKey + " has been uploaded for " + appData.ClientID, "Branch Accountant has uploaded '" + Input.DocumentKey + "' against the Application " + appData.ClientID);
                }

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<List<BADataCheckListDto>> GetBADocumentsByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _BADataCheckRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();


                return ObjectMapper.Map<List<BADataCheckListDto>>(filesList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", baDataChecks));
            }
        }

        public BADataCheckListDto GetFileByDocumentKey(int applicationId, string DocumentKey)
        {
            try
            {
                var objFile = _BADataCheckRepository.GetAllList().Where(x => x.ApplicationId == applicationId && x.DocumentKey == DocumentKey).FirstOrDefault();


                return ObjectMapper.Map<BADataCheckListDto>(objFile);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", baDataChecks));
            }
        }

        public string UpdateFile(int applicationId, string DocumentKey)
        {
            string ResponseString = "";
            try
            {
                var objFile = _BADataCheckRepository.GetAllList().Where(x => x.ApplicationId == applicationId && x.DocumentKey == DocumentKey).FirstOrDefault();

                if (objFile != null && objFile.Id > 0)
                {

                    _BADataCheckRepository.UpdateAsync(objFile);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Files Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", baDataChecks));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", baDataChecks));
            }
        }
        public string DeleteFile(int id)
        {
            string ResponseString = "";
            try
            {
                var objFile = _BADataCheckRepository.Get(id);

                if (objFile != null && objFile.Id > 0)
                {

                    _BADataCheckRepository.Delete(objFile);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Files Deleted Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", baDataChecks));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", baDataChecks));
            }
        }
    }
}
