using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Branches;
using TFCLPortal.Controllers;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Targets;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.Web.Models.Common;

namespace TFCLPortal.Web.Controllers
{
    public class TargetsController : TFCLPortalControllerBase
    {
        private readonly ITargetAppService _targetAppService;
        private readonly IRepository<Target> _targetRepository;
        private readonly IProductTypeAppService _productTypeAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly IUserAppService _userAppService;

        public TargetsController(IUserAppService userAppService,IBranchDetailAppService branchDetailAppService,IProductTypeAppService productTypeAppService,ITargetAppService targetAppService, IRepository<Target> targetRepository)
        {
            _userAppService = userAppService;
            _branchDetailAppService = branchDetailAppService;
            _productTypeAppService = productTypeAppService;
            _targetRepository = targetRepository;
            _targetAppService = targetAppService;
        }

        // GET: Targets
        public async Task<IActionResult> Index(TargetIndexModelFilter filter)
        {
            var targets = _targetAppService.GetAllAlocatedTarget();
            
            if(filter.Month!=null && filter.Month != 0)
            {
                targets = targets.Where(x => x.Month == filter.Month).ToList();
            }
            else
            {
                filter.Month = DateTime.Now.Month;
                targets = targets.Where(x => x.Month == DateTime.Now.Month).ToList();
            }

            if (filter.Year != null && filter.Year != 0)
            {
                targets = targets.Where(x => x.Year == filter.Year).ToList();
            }
            else
            {
                filter.Year = DateTime.Now.Year;
                targets = targets.Where(x => x.Year == DateTime.Now.Year).ToList();
            }

            if (filter.Fk_SdeId != null && filter.Fk_SdeId != 0)
            {
                targets = targets.Where(x => x.Fk_SdeId == filter.Fk_SdeId).ToList();
            }

            if (filter.Fk_ProductTypeId != null && filter.Fk_ProductTypeId != 0)
            {
                targets = targets.Where(x => x.Fk_ProductTypeId == filter.Fk_ProductTypeId).ToList();
            }

            if (filter.Fk_BranchId != null && filter.Fk_BranchId != 0)
            {
                targets = targets.Where(x => x.Fk_BranchId == filter.Fk_BranchId).ToList();
            }

            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<Users.Dto.UserDto> SdeUsers = new List<Users.Dto.UserDto>();

            foreach (var user in users)
            {
                if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                {

                    SdeUsers.Add(user);
                }

            }

            ViewBag.UserList = new SelectList(SdeUsers, "Id", "FullName");

            var products = _targetAppService.getProducts();
            ViewBag.ProductList = new SelectList(products, "Id", "Name");

            var branches = _branchDetailAppService.GetBranchListDetail();
            ViewBag.BranchList = new SelectList(branches, "Id", "BranchCode");


            TargetIndexModel model = new TargetIndexModel();

            model.Filters = filter;
            model.Targets = targets;

            return View(model);
        }

        // GET: Targets/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = _targetAppService.GetAllAlocatedTarget().Where(x=>x.Id==(int)id).SingleOrDefault();
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // GET: Targets/Create
        public async Task<IActionResult> Create()
        {
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<Users.Dto.UserDto> SdeUsers = new List<Users.Dto.UserDto>();

            foreach (var user in users)
            {
                if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                {

                    SdeUsers.Add(user);
                }

            }

            ViewBag.UserList = new SelectList(SdeUsers, "Id", "FullName");
            
            var products = _targetAppService.getProducts();
            ViewBag.ProductList = new SelectList(products, "Id", "Name");

            var branches = _branchDetailAppService.GetBranchListDetail();
            ViewBag.BranchList = new SelectList(branches, "Id", "BranchCode");


            return View();
        }

        // POST: Targets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Target target)
        {
            if (ModelState.IsValid)
            {
                _targetRepository.Insert(target);
                CurrentUnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(target);
        }

        // GET: Targets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target =  _targetRepository.Get((int)id);
            if (target == null)
            {
                return NotFound();
            }

            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<Users.Dto.UserDto> SdeUsers = new List<Users.Dto.UserDto>();

            foreach (var user in users)
            {
                if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                {

                    SdeUsers.Add(user);
                }

            }

            ViewBag.UserList = new SelectList(SdeUsers, "Id", "FullName");

            var products = _targetAppService.getProducts();
            ViewBag.ProductList = new SelectList(products, "Id", "Name");

            var branches = _branchDetailAppService.GetBranchListDetail();
            ViewBag.BranchList = new SelectList(branches, "Id", "BranchCode");

            return View(target);
        }

        // POST: Targets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, Target target)
        {
            if (id != target.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _targetRepository.Update(target);
                    CurrentUnitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetExists(target.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(target);
        }

        // GET: Targets/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = _targetAppService.GetAllAlocatedTarget().Where(x=>x.Id==(int)id).SingleOrDefault();
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // POST: Targets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var target = _targetRepository.Get((int)id);
            _targetRepository.Delete(target);
            CurrentUnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetExists(int id)
        {
            return _targetRepository.GetAllList().Any(e => e.Id == id);
        }
    }
}
