using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointment.Include(a => a.Doctor).Include(a => a.Patient)
                .Include(a => a.HospitalAndClinic).ThenInclude(x=>x.Hospital)
                .Include(x=>x.HospitalAndClinic).ThenInclude(x=>x.Clinic)
                .Select(x=> new AppointmentVM 
                {
                    Id= x.Id,
                    DoctorFullName = x.Doctor.FullName,
                    PatientFullName = x.Patient.FullName,
                    HospitalAndClinic = x.HospitalAndClinic.Hospital.Name + " "+x.HospitalAndClinic.Clinic.Name,
                    Time=x.Time
                });
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.HospitalAndClinic)
                .ThenInclude(x=>x.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName");
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x => x.Hospital).Include(x => x.Clinic).Select(x => new { Id = x.Id, Name = x.Hospital.Name + " " + x.Clinic.Name }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,Time,HospitalAndClinicId,DoctorId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", appointment.HospitalAndClinicId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointment.DoctorId);
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x => x.Hospital).Include(x => x.Clinic).Select(x => new { Id = x.Id, Name = x.Hospital.Name + " " + x.Clinic.Name }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name",appointment.HospitalAndClinicId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Time,HospitalAndClinicId,DoctorId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", appointment.HospitalAndClinicId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.HospitalAndClinic)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
