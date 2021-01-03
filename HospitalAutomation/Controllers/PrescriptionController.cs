using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.Prescription;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prescription
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prescription.Include(p => p.Examination).ThenInclude(x=>x.Appointment).ThenInclude(x=>x.Patient).Select(x=> new PrescriptionVM 
            { 
            Id = x.Id,
            PrescriptionNumber = x.PrescriptionNumber,
            Time = x.DateTime,
            Examination = x.Examination.Appointment.Patient.FullName + " " + x.Examination.Appointment.Time
            });
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prescription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Examination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: Prescription/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var examinations = _context.Examination.Include(x => x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Appointment.Patient.FullName + " " + x.Appointment.Time }).ToList();
            ViewData["Id"] = new SelectList(examinations, "Id", "FullName");
            return View();
        }

        // POST: Prescription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrescriptionNumber,DateTime")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Examination, "Id", "Id", prescription.Id);
            return View(prescription);
        }

        // GET: Prescription/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            var examinations = _context.Examination.Include(x => x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Appointment.Patient.FullName + " " + x.Appointment.Time }).ToList();
            ViewData["Id"] = new SelectList(examinations, "Id", "FullName",prescription.Id);
            return View(prescription);
        }

        // POST: Prescription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrescriptionNumber,DateTime")] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.Id))
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
            ViewData["Id"] = new SelectList(_context.Examination, "Id", "Id", prescription.Id);
            return View(prescription);
        }

        // GET: Prescription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Examination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.Id == id);
        }
    }
}
