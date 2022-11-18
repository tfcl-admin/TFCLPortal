using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.FilesUploads.Dto;
using TFCLPortal.FileTypes;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.FilesUploads
{
    public class FilesUploadAppService : TFCLPortalAppServiceBase, IFilesUploadAppService
    {
        private readonly IRepository<FilesUpload, int> _FilesUploadRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IFileTypeAppService _fileTypeAppService;

        public FilesUploadAppService(IFileTypeAppService fileTypeAppService,IRepository<FilesUpload, int> FilesUploadRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _FilesUploadRepository = FilesUploadRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _fileTypeAppService = fileTypeAppService;
        }

        public async Task<string> CreateFilesUpload(CreateFileUploadDto Input)
        {
            try
            {
                var filUpload = ObjectMapper.Map<FilesUpload>(Input);
                await _FilesUploadRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }

        public bool DeleteFileById(int Id)
        {

            try
            {
                var objFile = _FilesUploadRepository.Get(Id);

                _FilesUploadRepository.Delete(Id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public FilesUploadListDto GetFileByScreenCode(int applicationId, string ScreenCode)
        {

            try
            {
                var objFile = _FilesUploadRepository.GetAllList().Where(x => x.ApplicationId == applicationId && x.ScreenCode == ScreenCode).FirstOrDefault();


                return ObjectMapper.Map<FilesUploadListDto>(objFile);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }

        }

        public List<FilesUploadListDto> GetFilesByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _FilesUploadRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var files = ObjectMapper.Map<List<FilesUploadListDto>>(filesList);

                foreach (var file in files)
                {
                    if (file.Fk_idForName != 0)
                    {
                        if (file.ScreenCode.StartsWith("co_applicant"))
                        {
                            var coapplicantFile = _coApplicantDetailAppService.GetCoApplicantDetailById(file.Fk_idForName).Result.FirstOrDefault();
                            if (coapplicantFile != null)
                            {
                                file.RespectiveName = coapplicantFile.FullName;
                            }
                        }
                        else if (file.ScreenCode.StartsWith("guarantor"))
                        {
                            var guarantorFile = _guarantorDetailAppService.GetGuarantorDetailById(file.Fk_idForName).Result.FirstOrDefault();
                            if (guarantorFile != null)
                            {
                                file.RespectiveName = guarantorFile.FullName;
                            }
                        }

                    }
                }


                return files;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }
        public bool CheckFilesByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _FilesUploadRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                if (filesList.Count > 0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }
        public string UpdateFile(int applicationId, string ScreenCode)
        {

            string ResponseString = "";
            try
            {
                var objFile = _FilesUploadRepository.GetAllList().Where(x => x.ApplicationId == applicationId && x.ScreenCode == ScreenCode).FirstOrDefault();

                if (objFile != null && objFile.Id > 0)
                {

                    _FilesUploadRepository.UpdateAsync(objFile);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Files Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "File"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "File"));
            }

        }

        public string footerstring(int applicationId)
        {
            try
            {
                int aFiles = 0, gFiles = 0, cFiles = 0, tFiles=0;

                var files = GetFilesByApplicationId(applicationId);

                if (files != null)
                {
                    aFiles = files.Where(x => x.ScreenCode.StartsWith("applicant")).Count();
                    gFiles = files.Where(x => x.ScreenCode.StartsWith("guarantor")).Count();
                    cFiles = files.Where(x => x.ScreenCode.StartsWith("co_applicant")).Count();
                    tFiles = files.Count();
                }


                return "Applicant (" + aFiles + ") : Guarantor (" + gFiles + ") : Co-Applicant (" + cFiles + ") : Total Files (" + tFiles + ")";
            }
            catch
            {
                return "Applicant Files (0) : Guarantor Files (0) : Co-Applicant Files (0) : Total Files (0)";
            }
        }


        public string UploadImagestoServer(UploadFile document, string uploadApplication, string rootPath)
        {
            string filenameRtn = "";
            try
            {
                IFormFile image = document.UploadedFile;

                string extension = System.IO.Path.GetExtension(image.FileName);



                var fileType = _fileTypeAppService.GetById(document.FileTypeId);
                var filename = fileType.Code;

                var filePath = Path.Combine(uploadApplication, filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + extension);

                CreateFileUploadDto createdocumentUpload = new CreateFileUploadDto();
                createdocumentUpload.ApplicationId = document.ApplicationId;
                createdocumentUpload.FileUrl = "uploads/" + document.ApplicationId + "/" + filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + extension;
                createdocumentUpload.BaseUrl = rootPath + "/" + createdocumentUpload.FileUrl;
                createdocumentUpload.ScreenCode = filename;
                createdocumentUpload.Fk_idForName = document.ddrName;
                createdocumentUpload.Comments = document.Description;
                createdocumentUpload.UploadedBy = document.UploadedBy;
                CreateFilesUpload(createdocumentUpload);


                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                filenameRtn = filename.Replace("_"," ");
                return filenameRtn;

            }
            catch (Exception ex)
            {
                filenameRtn = "Error";
                return filenameRtn;
            }

        }

    }
}
