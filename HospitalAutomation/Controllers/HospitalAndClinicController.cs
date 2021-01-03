using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HospitalAndClinicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HospitalAndClinicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HospitalAndClinic
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HospitalAndClinic.Include(h => h.Clinic).Include(h => h.Hospital);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HospitalAndClinic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalAndClinic = await _context.HospitalAndClinic
                .Include(h => h.Clinic)
                .Include(h => h.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalAndClinic == null)
            {
                return NotFound();
            }

            return View(hospitalAndClinic);
        }

        // GET: HospitalAndClinic/Create
        public IActionResult Create()
        {
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Name");
            ViewData["HospitalId"] = new SelectList(_context.Hospital, "Id", "Name");
            return View();
        }

        // POST: HospitalAndClinic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HospitalId,ClinicId")] HospitalAndClinic hospitalAndClinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitalAndClinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Id", hospitalAndClinic.ClinicId);
            ViewData["HospitalId"] = new SelectList(_context.Hospital, "Id", "Id", hospitalAndClinic.HospitalId);
            return View(hospitalAndClinic);
        }

        // GET: HospitalAndClinic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalAndClinic = await _context.HospitalAndClinic.FindAsync(id);
            if (hospitalAndClinic == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Name", hospitalAndClinic.ClinicId);
            ViewData["HospitalId"] = new SelectList(_context.Hospital, "Id", "Name", hospitalAndClinic.HospitalId);
            return View(hospitalAndClinic);
        }

        // POST: HospitalAndClinic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HospitalId,ClinicId")] HospitalAndClinic hospitalAndClinic)
        {
            if (id != hospitalAndClinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitalAndClinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalAndClinicExists(hospitalAndClinic.Id))
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
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Id", hospitalAndClinic.ClinicId);
            ViewData["HospitalId"] = new SelectList(_context.Hospital, "Id", "Id", hospitalAndClinic.HospitalId);
            return View(hospitalAndClinic);
        }

        // GET: HospitalAndClinic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalAndClinic = await _context.HospitalAndClinic
                .Include(h => h.Clinic)
                .Include(h => h.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalAndClinic == null)
            {
                return NotFound();
            }

            return View(hospitalAndClinic);
        }

        // POST: HospitalAndClinic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospitalAndClinic = await _context.HospitalAndClinic.FindAsync(id);
            _context.HospitalAndClinic.Remove(hospitalAndClinic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalAndClinicExists(int id)
        {
            return _context.HospitalAndClinic.Any(e => e.Id == id);
        }
    }
}
