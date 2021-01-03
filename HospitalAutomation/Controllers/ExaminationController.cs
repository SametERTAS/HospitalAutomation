using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.Examination;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize]
    public class ExaminationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExaminationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Examination
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Examination.Include(e => e.Appointment).ThenInclude(x=>x.Patient).
                Include(x=>x.Appointment).ThenInclude(x=>x.HospitalAndClinic).ThenInclude(x=>x.Clinic).
                Include(x => x.Appointment).ThenInclude(x => x.HospitalAndClinic).ThenInclude(x => x.Hospital)
                .Select(x=> new ExaminationVM
                { 
                Id = x.Id,
                Diagnosis = x.Diagnosis,
                Appointment= x.Appointment.Patient.FullName + " " + x.Appointment.Time + " " + x.Appointment.HospitalAndClinic.Hospital.Name + " " + x.Appointment.HospitalAndClinic.Clinic.Name
                });
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Examination/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examination = await _context.Examination
                .Include(e => e.Appointment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examination == null)
            {
                return NotFound();
            }

            return View(examination);
        }

        // GET: Examination/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var appointments = _context.Appointment.Include(x => x.Patient).Select(x => new {Id= x.Id , FullName= x.Patient.FullName + " " + x.Time }).ToList();
            ViewData["Id"] = new SelectList(appointments, "Id", "FullName");
            return View();
        }

        // POST: Examination/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Diagnosis")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Appointment, "Id", "Id", examination.Id);
            return View(examination);
        }

        // GET: Examination/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examination = await _context.Examination.FindAsync(id);
            if (examination == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Appointment, "Id", "Id", examination.Id);
            return View(examination);
        }

        // POST: Examination/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnosis")] Examination examination)
        {
            if (id != examination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaminationExists(examination.Id))
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
            ViewData["Id"] = new SelectList(_context.Appointment, "Id", "Id", examination.Id);
            return View(examination);
        }

        // GET: Examination/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examination = await _context.Examination
                .Include(e => e.Appointment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examination == null)
            {
                return NotFound();
            }

            return View(examination);
        }

        // POST: Examination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examination = await _context.Examination.FindAsync(id);
            _context.Examination.Remove(examination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaminationExists(int id)
        {
            return _context.Examination.Any(e => e.Id == id);
        }
    }
}
