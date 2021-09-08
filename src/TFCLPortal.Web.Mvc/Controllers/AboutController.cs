using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Abp.AspNetCore.Mvc.Controllers;
using TFCLPortal.FilesUploads;
using TFCLPortal.FileTypes;
using TFCLPortal.Web.Models.UploadFiles;
using Microsoft.AspNetCore.Http;
using TFCLPortal.FilesUploads.Dto;
using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.CoApplicantDetails;
using System.Collections.Generic;

namespace TFCLPortal.Web.Controllers
{
    public class AboutController : AbpController
    {
        private readonly IFilesUploadAppService _filesUploadAppService;
        private readonly IFileTypeAppService _fileTypeAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IHostingEnvironment _env;
        public AboutController(IFilesUploadAppService filesUploadAppService, IHostingEnvironment env, IFileTypeAppService fileTypeAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _filesUploadAppService = filesUploadAppService;
            _fileTypeAppService = fileTypeAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _env = env;
        }
        public ActionResult Index(int id, string u, string Message, string MsgCSS)
        {
            ViewBag.Appid = id;
            ViewBag.UploadedBy = u;
            ViewBag.Msg = Message;
            ViewBag.MsgCSS = MsgCSS;
            var getFileUploads = _filesUploadAppService.GetFilesByApplicationId(id);

            ViewBag.totalFiles = getFileUploads.Count;

            var FileTypes = _fileTypeAppService.GetAllList();

            FileUploadModel model = new FileUploadModel();
            model.filesUploads = getFileUploads;
            model.fileTypes = FileTypes;

            List<GuarantorCoApplicant> guarantorCoApplicant = new List<GuarantorCoApplicant>();

            var guarantors = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(id).Result;
            if (guarantors != null)
            {
                foreach(var guarantor in guarantors)
                {
                    GuarantorCoApplicant ga = new GuarantorCoApplicant();
                    ga.Id = guarantor.Id;
                    ga.Name = guarantor.FullName + " (Guarantor)";
                    guarantorCoApplicant.Add(ga);
                }
            }

            var coapplicants = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(id).Result;
            if (coapplicants != null)
            {
                foreach (var coapplicant in coapplicants)
                {
                    GuarantorCoApplicant ga = new GuarantorCoApplicant();
                    ga.Id = coapplicant.Id;
                    ga.Name = coapplicant.FullName + " (Co-Applicant)";
                    guarantorCoApplicant.Add(ga);
                }
            }

            model.GuarantorCoApplicants = guarantorCoApplicant;


            return View(model);
        }

        public ActionResult VersionControl()
        {
            return View();
        }
        
        public ActionResult Entries()
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
                    bool check = UploadImagestoServer(documentUpload, uploadApplication, rootPath);

                    if (check)
                    {
                        Message = "File Uploaded Successfully.";
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
        //private static Regex r = new Regex(":");
        //public static DateTime GetDateTakenFromImage(string path)
        //{
        //    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    using (Image myImage = Image.FromStream(fs, false, false))
        //    {
        //        PropertyItem propItem = myImage.GetPropertyItem(36867);
        //        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
        //        return DateTime.Parse(dateTaken);
        //    }
        //}
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

    }
}
