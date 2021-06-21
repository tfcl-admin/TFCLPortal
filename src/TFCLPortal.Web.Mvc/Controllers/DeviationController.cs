using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Applications;
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;
using TFCLPortal.DeviationMatrices;
using TFCLPortal.DeviationMatrices.Dto;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;

namespace TFCLPortal.Web.Controllers
{
    [AbpMvcAuthorize]
    public class DeviationController : AbpController
    {
        private readonly IRepository<DeviationMatrix, int> _context;
        private readonly IDeviationMatrixAppService _deviationMatrixAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IHostingEnvironment _env;

        public DeviationController(IHostingEnvironment env,IRepository<DeviationMatrix, int> context, IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,IDeviationMatrixAppService deviationMatrixAppService)
        {
            _context = context;
            _env = env;
            _deviationMatrixAppService = deviationMatrixAppService;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }

        // GET: DeviationController
        public ActionResult Index()
        {
            var DeviationMatrices = _deviationMatrixAppService.GetDeviationMatrices();
            return View(DeviationMatrices);
        }

        // GET: DeviationController/Details/5
        public ActionResult Details(int id)
        {
            var DeviationMatrices = _deviationMatrixAppService.GetDeviationMatrixById(id);
            return View(DeviationMatrices);
        }

        // GET: DeviationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeviationController/Edit/5
        public ActionResult Edit(int id)
        {
            var DeviationMatrices = _deviationMatrixAppService.GetDeviationMatrixById(id);
            return View(DeviationMatrices);
        }

        // POST: DeviationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateDeviationMatrixDto collection)
        {
            try
            {
                var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");
                string rootPath= Path.Combine(Fileuploadpath, "ProductWiseDeviation");
                string fileName = "ProductWiseDeviation_"+DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string extension = System.IO.Path.GetExtension(collection.file.FileName);
                collection.approvalFileUrl= "/uploads/ProductWiseDeviation/"+fileName+ extension;

                UploadImagestoServer(collection.file,rootPath, fileName);

                var DeviationMatrices = _deviationMatrixAppService.UpdateDeviationMatrix(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string UploadImagestoServer(IFormFile image,  string rootPath, string DocumentName)
        {
            try
            {

                string extension = System.IO.Path.GetExtension(image.FileName);
                var filename = DocumentName;

                var filePath = Path.Combine(rootPath, filename + extension);

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                return filePath.ToString();

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        public ActionResult ApplicationWiseIndex()
        {
            var DeviationMatrices = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariables();
            return View(DeviationMatrices);
        }
        // GET: DeviationController/Details/5
        public ActionResult ApplicationWiseDetails(int id)
        {
            var DeviationMatrices = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(id);
            return View(DeviationMatrices);
        }

        // GET: DeviationController/Edit/5
        public ActionResult ApplicationWiseEdit(int id)
        {
            var DeviationMatrices = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(id);
            return View(DeviationMatrices);
        }

        // POST: DeviationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationWiseEdit(CreateApplicationWiseDeviationVariableDto collection)
        {
            try
            {
                var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");
                string rootPath = Path.Combine(Fileuploadpath, "ApplicationWiseDeviation");
                string fileName = collection.ApplicationId+"_ApplicationWiseDeviation_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string extension = System.IO.Path.GetExtension(collection.file.FileName);
                collection.approvalFileUrl = "/uploads/ApplicationWiseDeviation/" + fileName + extension;

                UploadImagestoServer(collection.file, rootPath, fileName);

                var DeviationMatrices = _applicationWiseDeviationVariableAppService.CreateApplicationWiseDeviationVariable(collection);
                return RedirectToAction(nameof(ApplicationWiseIndex));
            }
            catch
            {
                return View();
            }
        }

    }
}
