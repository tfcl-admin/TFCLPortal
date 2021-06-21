using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.ApplicationWorkFlows.BccStates;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.Controllers;
using TFCLPortal.Customs;
using TFCLPortal.Web.Host.Models;
using ApplicationState = TFCLPortal.Applications.Dto.ApplicationState;

namespace TFCLPortal.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchCreditCommitteeController : TFCLPortalControllerBase
    {
        private readonly IBranchCreditCommitteeAppService _branchCreditCommitteeAppService;
        private readonly IBccStateAppService _bccStateAppService;
        private readonly ICustomAppService _customAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationDescripantDeclineStateAppService _descripantDeclineStateAppService;

        public BranchCreditCommitteeController(IBranchCreditCommitteeAppService branchCreditCommitteeAppService,
            IBccStateAppService bccStateAppService,
           ICustomAppService customAppService,
           IApplicationAppService applicationAppService,
           IApplicationDescripantDeclineStateAppService descripantDeclineStateAppService)
        {
            _branchCreditCommitteeAppService = branchCreditCommitteeAppService;
            _bccStateAppService = bccStateAppService;
            _customAppService = customAppService;
            _applicationAppService = applicationAppService;
            _descripantDeclineStateAppService = descripantDeclineStateAppService;
        }


        [HttpPost("api/GetBranchCreditCommitteeListSDEUserId")]
        public ActionResult GetBranchCreditCommitteeListSDEUserId(BccUserSDE  bccUser)
        {


            try
            {
                var result = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListSDEUserId(bccUser.SDEUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "There is some issue on server while getting Bcc List");

            }



        }


        [HttpPost("api/ChangeApplicationStateByBCC")]
        public ActionResult ChangeApplicationStateByBCC(BCCModel bccUser)
        {
            if (bccUser.Status == "Decline")
            {
                UpdateBccStateDto updateBcc = new UpdateBccStateDto();
                updateBcc.ApplicationId = bccUser.ApplicationId;
                updateBcc.Fk_UserId = bccUser.SDEuserId;
                updateBcc.Status = "Decline";
                var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);
                _applicationAppService.ChangeApplicationState(TFCLPortal.Applications.Dto.ApplicationState.BCC_Decline, bccUser.ApplicationId, bccUser.Comments);

                var applicationObj = _applicationAppService.GetApplicationById(bccUser.ApplicationId);

                var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                declineStateDto.ApplicationId = bccUser.ApplicationId;
                declineStateDto.Fk_UserId = (int)applicationObj.CreatorUserId;
                declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                declineStateDto.IsActive = true;
                declineStateDto.Status = ApplicationState.BCC_Decline;
                declineStateDto.State = WorkFlowState.SDE;
                declineStateDto.Fk_BccId = result.Fk_BccId;
                _descripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                createWorkFlow.Fk_UserId = (int)applicationObj.CreatorUserId;
                createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                createWorkFlow.ApplicationId = bccUser.ApplicationId;
                createWorkFlow.IsActive = true;
                createWorkFlow.Status = ApplicationState.BCC_Decline;
                createWorkFlow.Fk_BccId = result.Fk_BccId;

                _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                return Ok("Sucess");
            }
            else if (bccUser.Status == "Descripent")
            {
                UpdateBccStateDto updateBcc = new UpdateBccStateDto();
                updateBcc.ApplicationId = bccUser.ApplicationId;
                updateBcc.Fk_UserId = bccUser.SDEuserId;
                updateBcc.Status = "Descripent";
                var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);
                _applicationAppService.ChangeApplicationState(ApplicationState.BCC_Descripent, bccUser.ApplicationId, bccUser.Comments);

                var applicationObj = _applicationAppService.GetApplicationById(bccUser.ApplicationId);

                var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                declineStateDto.ApplicationId = bccUser.ApplicationId;
                declineStateDto.Fk_UserId = (int)applicationObj.CreatorUserId;
                declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                declineStateDto.IsActive = true;
                declineStateDto.Status = ApplicationState.BCC_Descripent;
                declineStateDto.State = WorkFlowState.SDE;
                declineStateDto.Fk_BccId = result.Fk_BccId;
                _descripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                createWorkFlow.Fk_UserId = (int)applicationObj.CreatorUserId;
                createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                createWorkFlow.ApplicationId = bccUser.ApplicationId;
                createWorkFlow.IsActive = true;
                createWorkFlow.Status = ApplicationState.BCC_Decline;
                createWorkFlow.Fk_BccId = result.Fk_BccId;

                _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                return Ok("Sucess");
            }
            else
            {
                UpdateBccStateDto updateBcc = new UpdateBccStateDto();
                updateBcc.ApplicationId = bccUser.ApplicationId;
                updateBcc.Fk_UserId = bccUser.SDEuserId;
                updateBcc.Status = "Approved";
                try
                {
                    var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);

                    var IsApproved = _customAppService.GetBccApplicationApprovedStaus(bccUser.ApplicationId);
                    if (IsApproved.Result)
                    {
                        _applicationAppService.ChangeApplicationState(TFCLPortal.Applications.Dto.ApplicationState.BCC_Approved, bccUser.ApplicationId, "");

                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.BA);
                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = (int)workFlow.Result.UserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = bccUser.ApplicationId;
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = ApplicationState.BCC_Approved;
                        createWorkFlow.Fk_BccId = result.Fk_BccId;
                        _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                    }

                    return Ok("Success");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "There is some issue on server while changing the application state");

                }
            }



        }
    }
}