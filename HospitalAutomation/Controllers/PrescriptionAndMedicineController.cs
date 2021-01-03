using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.PrescriptionAndMedicine;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize]
    public class PrescriptionAndMedicineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionAndMedicineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrescriptionAndMedicine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrescriptionAndMedicine.Include(p => p.Medicine).Include(p => p.Prescription).ThenInclude(x=>x.Examination).ThenInclude(x=>x.Appointment).ThenInclude(x=>x.Patient).Select(x=> new PrescriptionAndMedicineVM
            { 
            Id = x.Id,
            MedicineName = x.Medicine.Name,
            PrescriptionInfo = x.Prescription.Examination.Appointment.Patient.FullName +" " + x.Prescription.Examination.Appointment.Time
            });
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrescriptionAndMedicine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionAndMedicine = await _context.PrescriptionAndMedicine
                .Include(p => p.Medicine)
                .Include(p => p.Prescription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionAndMedicine == null)
            {
                return NotFound();
            }

            return View(prescriptionAndMedicine);
        }
        [Authorize(Roles = "Admin")]
        // GET: PrescriptionAndMedicine/Create
        public IActionResult Create()
        {
            ViewData["MedicineId"] = new SelectList(_context.Medicine, "Id", "Name");
            var prescriptions = _context.Prescription.Include(p => p.Examination).ThenInclude(x => x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Examination.Appointment.Patient.FullName + " " + x.Examination.Appointment.Time }).ToList();
            ViewData["PrescriptionId"] = new SelectList(prescriptions, "Id", "FullName");
            return View();
        }

        // POST: PrescriptionAndMedicine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrescriptionId,MedicineId")] PrescriptionAndMedicine prescriptionAndMedicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescriptionAndMedicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineId"] = new SelectList(_context.Medicine, "Id", "Id", prescriptionAndMedicine.MedicineId);
            ViewData["PrescriptionId"] = new SelectList(_context.Prescription, "Id", "Id", prescriptionAndMedicine.PrescriptionId);
            return View(prescriptionAndMedicine);
        }
        [Authorize(Roles = "Admin")]
        // GET: PrescriptionAndMedicine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionAndMedicine = await _context.PrescriptionAndMedicine.FindAsync(id);
            if (prescriptionAndMedicine == null)
            {
                return NotFound();
            }
            ViewData["MedicineId"] = new SelectList(_context.Medicine, "Id", "Name", prescriptionAndMedicine.MedicineId);

            var prescriptions = _context.Prescription.Include(p => p.Examination).ThenInclude(x => x.Appointment).ThenInclude(x => x.Patient).Select(x => new { Id = x.Id, FullName = x.Examination.Appointment.Patient.FullName + " " + x.Examination.Appointment.Time }).ToList();
            ViewData["PrescriptionId"] = new SelectList(prescriptions, "Id", "FullName",prescriptionAndMedicine.PrescriptionId);
            return View(prescriptionAndMedicine);
        }

        // POST: PrescriptionAndMedicine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrescriptionId,MedicineId")] PrescriptionAndMedicine prescriptionAndMedicine)
        {
            if (id != prescriptionAndMedicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescriptionAndMedicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionAndMedicineExists(prescriptionAndMedicine.Id))
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
            ViewData["MedicineId"] = new SelectList(_context.Medicine, "Id", "Id", prescriptionAndMedicine.MedicineId);
            ViewData["PrescriptionId"] = new SelectList(_context.Prescription, "Id", "Id", prescriptionAndMedicine.PrescriptionId);
            return View(prescriptionAndMedicine);
        }

        // GET: PrescriptionAndMedicine/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionAndMedicine = await _context.PrescriptionAndMedicine
                .Include(p => p.Medicine)
                .Include(p => p.Prescription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionAndMedicine == null)
            {
                return NotFound();
            }

            return View(prescriptionAndMedicine);
        }

        // POST: PrescriptionAndMedicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescriptionAndMedicine = await _context.PrescriptionAndMedicine.FindAsync(id);
            _context.PrescriptionAndMedicine.Remove(prescriptionAndMedicine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionAndMedicineExists(int id)
        {
            return _context.PrescriptionAndMedicine.Any(e => e.Id == id);
        }
    }
}
