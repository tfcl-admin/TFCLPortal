using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Controllers;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Targets;

namespace TFCLPortal.Web.Controllers
{
    public class TargetsController : TFCLPortalControllerBase
    {
        private readonly ITargetAppService _targetAppService;
        private readonly IRepository<Target> _targetRepository;


        public TargetsController(ITargetAppService targetAppService, IRepository<Target> targetRepository)
        {
            _targetRepository = targetRepository;
            _targetAppService = targetAppService;
        }

        // GET: Targets
        public async Task<IActionResult> Index()
        {
            var targets = _targetAppService.GetAllAlocatedTarget();
            return View(targets);
        }

        // GET: Targets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = _targetAppService.GetTargetById((int)id);
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // GET: Targets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Targets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Target target)
        {
            if (ModelState.IsValid)
            {
                _targetRepository.InsertAsync(target);
                CurrentUnitOfWork.SaveChangesAsync();
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

            var target = await _targetRepository.GetAsync((int)id);
            if (target == null)
            {
                return NotFound();
            }
            return View(target);
        }

        // POST: Targets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Target target)
        {
            if (id != target.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _targetRepository.UpdateAsync(target);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _targetRepository.GetAsync((int)id);
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // POST: Targets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var target = await _targetRepository.GetAsync((int)id);
            _targetRepository.DeleteAsync(target);
            CurrentUnitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetExists(int id)
        {
            return _targetRepository.GetAllList().Any(e => e.Id == id);
        }
    }
}
