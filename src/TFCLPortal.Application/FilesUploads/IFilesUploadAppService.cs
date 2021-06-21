using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FilesUploads.Dto;

namespace TFCLPortal.FilesUploads
{
    public interface IFilesUploadAppService : IApplicationService
    {
        Task<string> CreateFilesUpload (CreateFileUploadDto Input);
        FilesUploadListDto GetFileByScreenCode(int applicationId,string ScreenCode);
        string UpdateFile(int applicationId, string ScreenCode);
        List<FilesUploadListDto> GetFilesByApplicationId(int ApplicationId);
        bool DeleteFileById(int Id);
        bool CheckFilesByApplicationId(int ApplicationId);
    }
}
