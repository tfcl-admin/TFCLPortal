using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Branches;
using TFCLPortal.Branches.Dto;
using TFCLPortal.Companies;
using TFCLPortal.Companies.Dto;
using TFCLPortal.Company.Dto;
using TFCLPortal.Controllers;
using TFCLPortal.Web.Models.Company;

namespace TFCLPortal.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class CompanyController : TFCLPortalControllerBase
    {
        private readonly ICompanyDetailAppService _companyDetailAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        public CompanyController(ICompanyDetailAppService companyDetailAppService , IBranchDetailAppService branchDetailAppService)
        {
            _companyDetailAppService = companyDetailAppService;
            _branchDetailAppService = branchDetailAppService;
        }
        public IActionResult Company()
        {
            var companyLists = _companyDetailAppService.GetCompanyListDetail();
            return View(companyLists);
        }
       
        
        public IActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyDetailDto model)
        {

            var createcompany = _companyDetailAppService.CreateCompanyDetail(model);
            return RedirectToAction("Company");
        }
        public IActionResult EditCompany(int Id)
        {
            var obj = _companyDetailAppService.GetCompanyDetailById(Id);
            return View(obj);
        }
        [HttpPost]
        public  IActionResult EditCompany(CompanyDetailListDto model)
        {
            

            UpdateCompanyDetailDto updateCompanyDetail = new UpdateCompanyDetailDto();

            updateCompanyDetail.Name = model.Name;
            updateCompanyDetail.Address = model.Address;
            updateCompanyDetail.GST = model.GST;
            updateCompanyDetail.Email = model.Email;
            updateCompanyDetail.Active = model.Active;
            updateCompanyDetail.Contact = model.Contact;
            updateCompanyDetail.NTN = model.NTN;
            updateCompanyDetail.Id = model.Id;

            var createcompany = _companyDetailAppService.UpdateCompanyDetail(updateCompanyDetail);
            return RedirectToAction("Company");
        }
        public IActionResult GetListCompany(int id)
        {
            var createcompany = _companyDetailAppService.GetCompanyDetailById(id);
            return View();
        }

        public IActionResult Branch()
        {
            var branchLists = _branchDetailAppService.GetBranchListDetail();
            return View(branchLists);
        }


        public IActionResult CreateBranch()
        {
            ViewBag.Company = new SelectList(_companyDetailAppService.GetCompanyListDetail(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateBranch(CreateBranchDetail model)
        {

            var createcompany = _branchDetailAppService.CreateBranchDetail(model);
            return RedirectToAction("Branch");
        }
        public IActionResult UpdateBranch()
        {
           //var updatebranch = _branchDetailAppService.UpdateBranchDetail();
            return View();
        }
        public IActionResult EditBranch(int Id)
        {
            var obj = _branchDetailAppService.GetBranchDetailById(Id);
            ViewBag.Company = new SelectList(_companyDetailAppService.GetCompanyListDetail(), "Id", "Name");

            return View(obj);
        }
        [HttpPost]
        public IActionResult EditBranch(BranchDetailList model)
        {


            UpdateBranchDetail updateBranchDetail = new UpdateBranchDetail();

            updateBranchDetail.BranchCode = model.BranchCode;
            updateBranchDetail.BranchName = model.BranchName;
            updateBranchDetail.ContactPerson = model.ContactPerson;
            updateBranchDetail.Email = model.Email;
            updateBranchDetail.TelNo = model.TelNo;
            updateBranchDetail.Active = model.Active;
            updateBranchDetail.Address = model.Address;
            updateBranchDetail.FK_companyid = model.FK_companyid;
            updateBranchDetail.Id = model.Id;

            var createcompany = _branchDetailAppService.UpdateBranchDetail (updateBranchDetail);
            return RedirectToAction("Branch");
        }
        public IActionResult GetListBranch(int id)
        {
            var listbranch = _branchDetailAppService.GetBranchDetailById(id);
            return View();
        }
    }
}