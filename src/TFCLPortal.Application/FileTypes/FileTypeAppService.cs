using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FileTypes.Dto;

namespace TFCLPortal.FileTypes
{
    public class FileTypeAppService : TFCLPortalAppServiceBase, IFileTypeAppService
    {
        private readonly IRepository<FileType, int> _FileTypeRepository;

        public FileTypeAppService(IRepository<FileType, int> FileTypeRepository)
        {
            _FileTypeRepository = FileTypeRepository;
        }
        public async Task<string> CreateFilesType(CreateFileTypeDto Input)
        {
            try
            {
                var filType = ObjectMapper.Map<FileType>(Input);
                await _FileTypeRepository.InsertAsync(filType);
                CurrentUnitOfWork.SaveChanges();

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }

        public List<FileTypeListDto> GetAllList()
        {
            try
            {
                var fileTypeList = _FileTypeRepository.GetAllList().ToList();
                return ObjectMapper.Map<List<FileTypeListDto>>(fileTypeList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "File Types"));
            }
        }

        public string DeleteFileType(int Id)
        {

            string ResponseString = "";
            try
            {
                var objFile = _FileTypeRepository.GetAllList().Where(x => x.Id == Id).FirstOrDefault();

                if (objFile != null && objFile.Id > 0)
                {

                    _FileTypeRepository.Delete(objFile);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Files Type Deleted Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "File Types"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "File Types"));
            }

        }

        public FileTypeListDto GetById(int Id)
        {
            try
            {
                var fileType = _FileTypeRepository.GetAllList().Where(x=>x.Id==Id).FirstOrDefault();
                return ObjectMapper.Map<FileTypeListDto>(fileType);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "File Type"));
            }
        }
    }
}