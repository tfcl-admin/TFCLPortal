using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.BADataChecks.Dto;

namespace TFCLPortal.ApplicationWorkFlows.BADataChecks
{
   public interface IBADataCheckAppService : IApplicationService
    {
        Task<string> CreateBADocumentUpload(CreateBADataCheckDto Input);
        BADataCheckListDto GetFileByDocumentKey(int applicationId, string DocumentKey);
        string UpdateFile(int applicationId, string DocumentKey);
        Task<List<BADataCheckListDto>> GetBADocumentsByApplicationId(int ApplicationId);
        string DeleteFile(int id);
    }
}
