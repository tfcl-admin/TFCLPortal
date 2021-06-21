using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.FilesUploads.Dto;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.FilesUploads
{
    public class FilesUploadAppService : TFCLPortalAppServiceBase, IFilesUploadAppService
    {
        private readonly IRepository<FilesUpload, int> _FilesUploadRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public FilesUploadAppService(IRepository<FilesUpload, int> FilesUploadRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _FilesUploadRepository = FilesUploadRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

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
                    if(file.Fk_idForName!=0)
                    {
                        if (file.ScreenCode.StartsWith("co_applicant"))
                        {
                            var coapplicantFile=_coApplicantDetailAppService.GetCoApplicantDetailById(file.Fk_idForName).Result.FirstOrDefault();
                            if(coapplicantFile!=null)
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
                if (filesList.Count>0)
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
    }
}
