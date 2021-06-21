using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TFCLPortal.Applications;
using TFCLPortal.Controllers;
using TFCLPortal.Web.Host.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TFCLPortal.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : TFCLPortalControllerBase
    {
        private readonly IApplicationAppService _applicationAppService;

        public ApplicationController(IApplicationAppService applicationAppService)
        {
            _applicationAppService = applicationAppService;
        }

        [HttpPost("api/ChangeApplicationState")]
        public ActionResult GetBADataCheckDoscument(ApplicationState applicationModel)
        {


            try
            {
                var result = _applicationAppService.ChangeApplicationState(applicationModel.AppState, applicationModel.ApplicationId,applicationModel.Comments);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return   StatusCode(500, "There is some issue on server for changing application state");

            }
        }


        [HttpPost("api/GetDeclineApplicationByUserId")]
        public ActionResult GetDeclineApplicationByUserId(User user)
        {
            

            try
            {
                var result = _applicationAppService.GetDeclineApplicationbyUserId(user.CurrentUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "There is some issue on server for changing application state");

            }
        }

        [HttpPost("api/GetDescripentApplicationbyUserId")]
        public ActionResult GetDescripentApplicationbyUserId(User user)
        {


            try
            {
                var result = _applicationAppService.GetDescripentApplicationbyUserId(user.CurrentUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "There is some issue on server for changing application state");

            }
        }
    }
}