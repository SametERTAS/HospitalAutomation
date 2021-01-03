using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.ExaminationAndTest;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize]
    public class ExaminationAndTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExaminationAndTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
         
         var applicationDbContext = _context.Examination.Include(e => e.Appointment).ThenInclude(x=>x.Patient).
                Include(x=>x.Appointment).ThenInclude(x=>x.HospitalAndClinic).ThenInclude(x=>x.Clinic).
                Include(x => x.Appointment).ThenInclude(x => x.HospitalAndClinic).ThenInclude(x => x.Hospital)
                .Select(x=> new ExaminationVM
                { 
                Id = x.Id,
                Diagnosis = x.Diagnosis,
                Appointment= x.Appointment.Patient.FullName + " " + x.Appointment.Time + " " + x.Appointment.HospitalAndClinic.Hospital.Name + " " + x.Appointment.HospitalAndClinic.Clinic.Name
                });
         
         */









        // GET: ExaminationAndTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExaminationAndTest.Include(e => e.Test)
                .Include(e => e.Examination).ThenInclude(x=>x.Appointment).ThenInclude(x => x.HospitalAndClinic).ThenInclude(x => x.Clinic)
                .Include(x=>x.Examination).ThenInclude(x => x.Appointment).ThenInclude(x => x.HospitalAndClinic).ThenInclude(x => x.Hospital)
                .Include(e => e.Examination).ThenInclude(x => x.Appointment).ThenInclude(x=>x.Patient)
                .Select(x=>new ExaminationAndTestVM
                { 
                Id=x.Id,
                PatientInfo = x.Examination.Appointment.Patient.FullName + " " + x.Examination.Appointment.Time + " "+ x.Examination.Appointment.HospitalAndClinic.Hospital.Name + " " + x.Examination.Appointment.HospitalAndClinic.Clinic.Name,
                TestName = x.Test.Name
                
                });

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExaminationAndTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examinationAndTest = await _context.ExaminationAndTest
                .Include(e => e.Examination)
                .Include(e => e.Test)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinationAndTest == null)
            {
                return NotFound();
            }

            return View(examinationAndTest);
        }

        // GET: ExaminationAndTest/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var examinations = _context.Examination.Include(x=>x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Appointment.Patient.FullName + " " + x.Appointment.Time }).ToList();
            ViewData["ExaminationId"] = new SelectList(examinations, "Id", "FullName");
            ViewData["TestId"] = new SelectList(_context.Test, "Id", "Name");
            return View();
        }

        // POST: ExaminationAndTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExaminationId,TestId")] ExaminationAndTest examinationAndTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examinationAndTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExaminationId"] = new SelectList(_context.Examination, "Id", "Id", examinationAndTest.ExaminationId);
            ViewData["TestId"] = new SelectList(_context.Test, "Id", "Id", examinationAndTest.TestId);
            return View(examinationAndTest);
        }

        // GET: ExaminationAndTest/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examinationAndTest = await _context.ExaminationAndTest.FindAsync(id);
            if (examinationAndTest == null)
            {
                return NotFound();
            }

            var examinations = _context.Examination.Include(x => x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Appointment.Patient.FullName + " " + x.Appointment.Time }).ToList();
            ViewData["ExaminationId"] = new SelectList(examinations, "Id", "FullName",examinationAndTest.ExaminationId);
            ViewData["TestId"] = new SelectList(_context.Test, "Id", "Name", examinationAndTest.TestId);
            return View(examinationAndTest);
        }

        // POST: ExaminationAndTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExaminationId,TestId")] ExaminationAndTest examinationAndTest)
        {
            if (id != examinationAndTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examinationAndTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaminationAndTestExists(examinationAndTest.Id))
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
            ViewData["ExaminationId"] = new SelectList(_context.Examination, "Id", "Id", examinationAndTest.ExaminationId);
            ViewData["TestId"] = new SelectList(_context.Test, "Id", "Id", examinationAndTest.TestId);
            return View(examinationAndTest);
        }

        // GET: ExaminationAndTest/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examinationAndTest = await _context.ExaminationAndTest
                .Include(e => e.Examination)
                .Include(e => e.Test)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinationAndTest == null)
            {
                return NotFound();
            }

            return View(examinationAndTest);
        }

        // POST: ExaminationAndTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examinationAndTest = await _context.ExaminationAndTest.FindAsync(id);
            _context.ExaminationAndTest.Remove(examinationAndTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaminationAndTestExists(int id)
        {
            return _context.ExaminationAndTest.Any(e => e.Id == id);
        }
    }
}
