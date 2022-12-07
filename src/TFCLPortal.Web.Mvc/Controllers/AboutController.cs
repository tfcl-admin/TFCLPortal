using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.Controllers;
using TFCLPortal.FilesUploads;
using TFCLPortal.FilesUploads.Dto;
using TFCLPortal.FileTypes;
using TFCLPortal.FileTypes.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.Web.Models.UploadFiles;

namespace TFCLPortal.Web.Controllers
{
    public class AboutController : AbpController
    {
        private readonly IFilesUploadAppService _filesUploadAppService;
        private readonly IFileTypeAppService _fileTypeAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IHostingEnvironment _env;
        public AboutController(IFilesUploadAppService filesUploadAppService, IHostingEnvironment env,
            IFileTypeAppService fileTypeAppService, IGuarantorDetailAppService guarantorDetailAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _filesUploadAppService = filesUploadAppService;
            _fileTypeAppService = fileTypeAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _env = env;
        }

        public IActionResult StudentList()
        {
            return View();
        }
        public ActionResult Index(int id, string u, string Message, string MsgCSS)
        {
            ViewBag.Appid = id;
            ViewBag.UploadedBy = u;
            ViewBag.Msg = Message;
            ViewBag.MsgCSS = MsgCSS;
            var footerstring = _filesUploadAppService.footerstring(id);

            ViewBag.footerstring = footerstring;

            var FileTypes = _fileTypeAppService.GetAllList();

            FileUploadModel model = new FileUploadModel();
            //model.filesUploads = getFileUploads;
            model.ApplicationId = id;
            model.fileTypes = FileTypes;
            model.GuarantorCoApplicants = _fileTypeAppService.GetGuarantorCoApplicants(id);


            return View(model);
        }

        public ActionResult VersionControl()
        {
            return View();
        }

        public ActionResult ViewFiles(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;
            ViewBag.OnTab = 1;

            return View();
        }
        public ActionResult ViewFilesAll(int ApplicationId,int OnTab)
        {
            ViewBag.Applicationid = ApplicationId;
            
            if(OnTab == 1)
            {
                ViewBag.OnTab = 1;
            }
            else if(OnTab==0)
            {
                ViewBag.OnWeb = 1;
            }

            return View();
        }
        public JsonResult getFilesByApplicationId(int ApplicationId)
        {
            var result = _filesUploadAppService.GetFilesByApplicationId(ApplicationId);
            return Json(result);
        }
        //[HttpPost]
        public IActionResult ReturnPartialView(int ApplicationId)
        {
            ViewBag.UploadedDocumentsAction = "Hide";


            var data = _filesUploadAppService.GetFilesByApplicationId(ApplicationId);

            return PartialView("_attachDocuments", data);
        }

        public ActionResult Entries()
        {
            return View();
        }

        public ActionResult CalculationEntries()
        {
            return View();
        }

        public JsonResult FetchFileTypes()
        {
            var FileTypes = _fileTypeAppService.GetAllList();
            return Json(FileTypes);
        }


        public JsonResult FetchNames(string selectedText, int applicationId)
        {
            if (selectedText.StartsWith("Co-Applicant"))
            {
                var Names = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(applicationId);
                return Json(Names);
            }
            else if (selectedText.StartsWith("Guarantor"))
            {
                var Names = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(applicationId);
                return Json(Names);
            }
            else
            {
                return Json("");
            }

        }

        public ActionResult DeleteFile(int id, int AppicationId, string UploadedBy)
        {
            string Message = "";
            string MsgCSS = "";

            if (_filesUploadAppService.DeleteFileById(id))
            {
                Message = "Document deleted successfuly";
                MsgCSS = "text-green";
            }
            else
            {
                Message = "Some error occured while deleting the document";
                MsgCSS = "text-red";
            }





            return RedirectToAction("Index", new { id = AppicationId, u = UploadedBy, Message = Message, MsgCSS = MsgCSS });
        }

        //[HttpGet]
        //public ActionResult UploadFile()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult UploadFile(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(_env.WebRootPath + "/UploadedFiles", _FileName);
        //            file.SaveAs(_path);
        //        }
        //        ViewBag.Message = "File Uploaded Successfully!!";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed!!";
        //        return View();
        //    }
        //}

        [HttpPost]
        public IActionResult UploadFileToServer([FromForm] UploadFile documentUpload)
        {
            string Message = "";
            string MsgCSS = "";
            string rootPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string AppicationId = documentUpload.ApplicationId.ToString();

            var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");

            bool exists = System.IO.Directory.Exists(Fileuploadpath);
            if (!exists)
                System.IO.Directory.CreateDirectory(Fileuploadpath);


            var uploadApplication = Path.Combine(Fileuploadpath, AppicationId);
            bool existsApplication = System.IO.Directory.Exists(uploadApplication);
            if (!existsApplication)
                System.IO.Directory.CreateDirectory(uploadApplication);

            string extension = System.IO.Path.GetExtension(documentUpload.UploadedFile.FileName);

            if (extension == ".pdf" || extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".xls" || extension == ".xlsx" || extension == ".csv" || extension == ".doc" || extension == ".docx")
            {
                if (documentUpload.UploadedFile.Length < 5242880)
                {
                    string check = _filesUploadAppService.UploadImagestoServer(documentUpload, uploadApplication, rootPath);

                    if (check != "" && check != "Error")
                    {
                        Message = check+" Uploaded Successfully.";
                        MsgCSS = "text-green";
                    }
                    else
                    {
                        Message = "Error occured while uploading file.";
                        MsgCSS = "text-red";
                    }

                }
                else
                {
                    Message = "Please select a smaller file. Max Limit of file size is 5mb.";
                    MsgCSS = "text-red";
                }

            }
            else
            {
                Message = extension + " is an Invalid Extenstion. Please select file of these extensions (pdf, jpg, jpeg, png). ";
                MsgCSS = "text-red";
            }




            return RedirectToAction("Index", new { id = AppicationId, u = documentUpload.UploadedBy, Message = Message, MsgCSS = MsgCSS });
        }

        private bool UploadImagestoServer(UploadFile document, string uploadApplication, string rootPath)
        {
            try
            {
                IFormFile image = document.UploadedFile;

                string extension = System.IO.Path.GetExtension(image.FileName);



                var fileType = _fileTypeAppService.GetById(document.FileTypeId);
                var filename = fileType.Code;

                //if (image.FileName.Contains("."))
                //{
                //    filename = "";
                //}

                //var filePath = Path.Combine(uploadApplication, "uploads/" + document.ApplicationId + "/" + filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") +  extension);
                var filePath = Path.Combine(uploadApplication, filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + extension);

                //if (!System.IO.File.Exists(filePath))
                //{

                CreateFileUploadDto createdocumentUpload = new CreateFileUploadDto();
                createdocumentUpload.ApplicationId = document.ApplicationId;
                createdocumentUpload.FileUrl = "uploads/" + document.ApplicationId + "/" + filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + extension;
                createdocumentUpload.BaseUrl = rootPath + "/" + createdocumentUpload.FileUrl;
                createdocumentUpload.ScreenCode = filename;
                createdocumentUpload.Fk_idForName = document.ddrName;
                createdocumentUpload.Comments = document.Description;
                createdocumentUpload.UploadedBy = document.UploadedBy;
                _filesUploadAppService.CreateFilesUpload(createdocumentUpload);

                //DateTime dt = GetDateTakenFromImage(createdocumentUpload.BaseUrl);

                //}
                //else
                //{

                //    var filePath2 = Path.Combine(uploadApplication + "_deleted_", DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’mm’ss") + "_" + filename + extension);

                //    //bool existsApplication = System.IO.Directory.Exists(uploadApplication + "/deleted/");
                //    //if (!existsApplication)
                //    //    System.IO.Directory.CreateDirectory(uploadApplication + "/deleted/");
                //    //// Move the file.
                //    System.IO.File.Move(filePath, filePath2);

                //    if (System.IO.File.Exists(filePath))
                //        System.IO.File.Delete(filePath);


                //}



                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IActionResult Success(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }
        public IActionResult Error(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }

    }
}
