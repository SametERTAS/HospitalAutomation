using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.ViewModels.Doctor;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =await _context.Doctor.Include(e => e.City).Include(e => e.Country)
                 .Include(e => e.HospitalAndClinic).ThenInclude(x => x.Clinic)
                 .Include(x => x.HospitalAndClinic).ThenInclude(x => x.Hospital)
                 .Select(x => new DoctorVM
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Adress = x.Adress,
                     AdressCity = x.City.Name,
                     Country = x.Country.Name,
                     MobileNumber = x.MobileNumber,
                     HomeNumber = x.HomeNumber,
                     BusinessNumber = x.BusinessNumber,
                     Nationality = x.Nationality,
                     HomeTown = x.HomeTown,
                     IdentificationNumber = x.IdentificationNumber,
                     BirthDate = x.BirthDate,
                     BloodType = x.BloodType,
                     MaritalStatu = x.MaritalStatu,
                     Gender = x.Gender,
                     Branch = x.Branch,
                     HospitalAndClinic = x.HospitalAndClinic.Hospital.Name + " " + x.HospitalAndClinic.Clinic.Name
                 }).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.City)
                .Include(d => d.Country)
                .Include(d => d.HospitalAndClinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Name");
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Name");
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x => x.Hospital).Include(x => x.Clinic).Select(x => new { Id = x.Id, Name = x.Hospital.Name + " " + x.Clinic.Name }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Branch,HospitalAndClinicId,Id,FirstName,LastName,Adress,AdressCity,MobileNumber,HomeNumber,BusinessNumber,Nationality,HomeTown,IdentificationNumber,BirthDate,Gender,MaritalStatu,BloodType")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Id", doctor.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Id", doctor.Nationality);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", doctor.HospitalAndClinicId);
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Name", doctor.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Name", doctor.Nationality);
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x => x.Hospital).Include(x => x.Clinic).Select(x => new { Id = x.Id, Name = x.Hospital.Name + " " + x.Clinic.Name }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name",doctor.HospitalAndClinicId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Branch,HospitalAndClinicId,Id,FirstName,LastName,Adress,AdressCity,MobileNumber,HomeNumber,BusinessNumber,Nationality,HomeTown,IdentificationNumber,BirthDate,Gender,MaritalStatu,BloodType")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Id", doctor.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Id", doctor.Nationality);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", doctor.HospitalAndClinicId);
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.City)
                .Include(d => d.Country)
                .Include(d => d.HospitalAndClinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
