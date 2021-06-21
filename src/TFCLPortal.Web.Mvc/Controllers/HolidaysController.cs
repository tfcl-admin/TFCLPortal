using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Controllers;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Holidays;

namespace TFCLPortal.Web.Controllers
{
    public class HolidaysController : TFCLPortalControllerBase
    {
        private readonly IRepository<Holiday> _holidayRepository;

        public HolidaysController(IRepository<Holiday> holidayRepositorys)
        {
            _holidayRepository = holidayRepositorys;
        }

        // GET: Holidays
        public async Task<IActionResult> Index()
        {
            return View(await _holidayRepository.GetAllListAsync());
        }

        // GET: Holidays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holiday = _holidayRepository.GetAllList(m => m.Id == id).FirstOrDefault();
            if (holiday == null)
            {
                return NotFound();
            }

            return View(holiday);
        }

        // GET: Holidays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [DisableValidation]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Holiday holiday)
        {
            _holidayRepository.Insert(holiday);
            return RedirectToAction(nameof(Index));

            return View(holiday);
        }

        // GET: Holidays/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var holiday = _holidayRepository.Get(id);
            if (holiday == null)
            {
                return NotFound();
            }
            return View(holiday);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableValidation]
        public async Task<IActionResult> Edit(int id, Holiday holiday)
        {
            if (id != holiday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _holidayRepository.Update(holiday);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolidayExists(holiday.Id))
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
            return View(holiday);
        }

        // GET: Holidays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holiday = _holidayRepository.GetAllList(m => m.Id == id).FirstOrDefault();
            if (holiday == null)
            {
                return NotFound();
            }

            return View(holiday);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [DisableValidation]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holiday = _holidayRepository.Get(id);
            _holidayRepository.Delete(holiday);

            return RedirectToAction(nameof(Index));
        }

        private bool HolidayExists(int id)
        {
            var holiday = _holidayRepository.Get(id);
            if (holiday != null)
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
