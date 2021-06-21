using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Controllers;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.EntityFrameworkCore;

namespace TFCLPortal.Web.Controllers
{
    public class AcademicSessionsController : TFCLPortalControllerBase
    {
        private readonly IRepository<AcademicSession, int> _context;

        public AcademicSessionsController(IRepository<AcademicSession, int> context)
        {
            _context = context;
        }

        // GET: AcademicSessions
        public IActionResult Index()
        {
            var list = _context.GetAllList();
            var mappedList = ObjectMapper.Map<List<AcademicSessionListDto>>(list);
            return View(mappedList);
        }

        // GET: AcademicSessions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicSession = await _context.GetAsync(id);
            if (academicSession == null)
            {
                return NotFound();
            }

            return View(academicSession);
        }

        // GET: AcademicSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId,Id")] AcademicSession academicSession)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertAsync(academicSession);
                CurrentUnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(academicSession);
        }

        // GET: AcademicSessions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicSession = await _context.GetAsync(id);
            if (academicSession == null)
            {
                return NotFound();
            }
            return View(academicSession);
        }

        // POST: AcademicSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId,Id")] AcademicSession academicSession)
        {
            if (id != academicSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicSession);
                    CurrentUnitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicSessionExists(academicSession.Id))
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
            return View(academicSession);
        }

        // GET: AcademicSessions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicSession = await _context.GetAsync(id);
            if (academicSession == null)
            {
                return NotFound();
            }

            return View(academicSession);
        }

        // POST: AcademicSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicSession = await _context.GetAsync(id);
            _context.Delete(academicSession);
            CurrentUnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicSessionExists(int id)
        {
            var exists=_context.GetAsync(id);

            if (exists != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
