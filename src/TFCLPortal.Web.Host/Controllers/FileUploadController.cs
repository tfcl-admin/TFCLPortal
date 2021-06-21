using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.ApplicationWorkFlows.BADataChecks;
using TFCLPortal.Controllers;
using TFCLPortal.FilesUploads;
using TFCLPortal.FilesUploads.Dto;
using TFCLPortal.Web.Host.Models;

namespace TFCLPortal.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : TFCLPortalControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly IFilesUploadAppService _filesUploadAppService;
        private readonly IBADataCheckAppService _BADataCheckAppService;

        public FileUploadController(IHostingEnvironment env, IFilesUploadAppService filesUploadAppService, IBADataCheckAppService BADataCheckAppService)
        {
            _env = env;
            _filesUploadAppService = filesUploadAppService;
            _BADataCheckAppService = BADataCheckAppService;
        }
        [HttpPost("api/Upload")]
        public ActionResult Upload([FromForm]FileUpload file)
        {
            // Getting Name
            // string contentRootPath = _env.ContentRootPath;
            try
            {
                string rootPath =   $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";                
                string AppicationId = file.ApplicationId.ToString();
                          
                var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");

                bool exists = System.IO.Directory.Exists(Fileuploadpath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(Fileuploadpath);


                var uploadApplication = Path.Combine(Fileuploadpath, AppicationId);
                bool existsApplication = System.IO.Directory.Exists(uploadApplication);
                if (!existsApplication)
                    System.IO.Directory.CreateDirectory(uploadApplication);

                if (file.applicant_photo != null)
                {
                    UploadImagestoServer(file.applicant_photo, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_photo));   
                }

                if (file.applicant_cnic_front != null)
                {
                    UploadImagestoServer(file.applicant_cnic_front, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_cnic_front));
                }

                if (file.applicant_cnic_back != null)
                {
                    UploadImagestoServer(file.applicant_cnic_back, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_cnic_back));
                }
                if (file.applicant_utility_bil_one != null)
                {
                    UploadImagestoServer(file.applicant_utility_bil_one, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_utility_bil_one));
                }
                if (file.applicant_utility_bil_two != null)
                {
                    UploadImagestoServer(file.applicant_utility_bil_two, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_utility_bil_two));
                }
                if (file.applicant_school_reg_certification != null)
                {
                    UploadImagestoServer(file.applicant_school_reg_certification, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_school_reg_certification));
                }
                if (file.applicant_school_front_view != null)
                {
                    UploadImagestoServer(file.applicant_school_front_view, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_school_front_view));
                }
                if (file.applicant_rent_agreement != null)
                {
                    UploadImagestoServer(file.applicant_rent_agreement, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_rent_agreement));
                }
                if (file.applicant_other_document_one != null)
                {
                    UploadImagestoServer(file.applicant_other_document_one, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_other_document_one));
                }
                if (file.applicant_other_document_two != null)
                {
                    UploadImagestoServer(file.applicant_other_document_two, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.applicant_other_document_two));
                }
                if (file.guarantor_photo != null)
                {
                    UploadImagestoServer(file.guarantor_photo, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_photo));
                }
                if (file.guarantor_cnic_front != null)
                {
                    UploadImagestoServer(file.guarantor_cnic_front, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_cnic_front));
                }
                if (file.guarantor_cnic_back != null)
                {
                    UploadImagestoServer(file.guarantor_cnic_back, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_cnic_back));
                }
                if (file.guarantor_employment_card != null)
                {
                    UploadImagestoServer(file.guarantor_employment_card, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_employment_card));
                }
                if (file.guarantor_additional_document_one != null)
                {
                    UploadImagestoServer(file.guarantor_additional_document_one, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_additional_document_one));
                }
                if (file.guarantor_additional_document_two != null)
                {
                    UploadImagestoServer(file.guarantor_additional_document_two, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.guarantor_additional_document_two));
                }
                if (file.co_applicant_photo != null)
                {
                    UploadImagestoServer(file.co_applicant_photo, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.co_applicant_photo));
                }
                if (file.co_applicant_cnic_front != null)
                {
                    UploadImagestoServer(file.co_applicant_cnic_front, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.co_applicant_cnic_front));
                }
                if (file.co_applicant_cnic_back != null)
                {
                    UploadImagestoServer(file.co_applicant_cnic_back, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.co_applicant_cnic_back));

                }
                if (file.co_applicant_additional_document_one != null)
                {
                    UploadImagestoServer(file.co_applicant_additional_document_one, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.co_applicant_additional_document_one));
                }
                if (file.co_applicant_additional_document_two != null)
                {
                    UploadImagestoServer(file.co_applicant_additional_document_two, uploadApplication, file.ApplicationId, rootPath, nameof(FileUploadString.co_applicant_additional_document_two));
                }
               
            }
            catch (Exception ex)
            { 
            
            }
            return Ok(new { status = true, message = "Files upload successfully" });
        }

        private void UploadImagestoServer(IFormFile image,string uploadApplication,int applicationId,string rootPath,string screenCode)
        {
            try {

                string extension = System.IO.Path.GetExtension(image.FileName);
                var filename = "Test";
                if (image.FileName.Contains("."))
                {
                    filename = screenCode;
                }

                var filePath = Path.Combine(uploadApplication, filename + extension);

                if (!System.IO.File.Exists(filePath))
                {

                    CreateFileUploadDto createFileUpload = new CreateFileUploadDto();
                    createFileUpload.ApplicationId = applicationId;
                    createFileUpload.FileUrl = "uploads/" + applicationId + "/" + filename + extension;
                    createFileUpload.BaseUrl = rootPath + "/" + createFileUpload.FileUrl;
                    createFileUpload.ScreenStatus = "Inprocessing";
                    createFileUpload.ScreenCode = screenCode;
                    _filesUploadAppService.CreateFilesUpload(createFileUpload);
                }
                else
                {

                    _filesUploadAppService.UpdateFile(applicationId, screenCode);

                }


                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                


            }
            catch (Exception ex)
            {

            }

        }
        
        
        [HttpPost("api/GetBADataCheckDocument")]
        public ActionResult GetBADataCheckDoscument([FromBody]BADocument Document)
        {
            try
            {


                var result = _BADataCheckAppService.GetBADocumentsByApplicationId(Document.ApplicationId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "There is some issue while getting data check attachments");

            }


        }

    }
}