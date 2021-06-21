using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FileTypes.Dto;

namespace TFCLPortal.FileTypes
{
    public interface IFileTypeAppService : IApplicationService
    {
        Task<string> CreateFilesType(CreateFileTypeDto Input);
        string DeleteFileType(int Id);
        List<FileTypeListDto> GetAllList();
        FileTypeListDto GetById(int Id);
    }
}
