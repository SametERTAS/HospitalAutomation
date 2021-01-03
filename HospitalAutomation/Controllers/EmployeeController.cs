using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalAutomation.Data;
using HospitalAutomation.Models;
using HospitalAutomation.Models.Enums;
using HospitalAutomation.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAutomation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.City).Include(e => e.Country)
                .Include(e => e.HospitalAndClinic).ThenInclude(x => x.Clinic)
                .Include(x => x.HospitalAndClinic).ThenInclude(x => x.Hospital)
                .Select(x => new EmployeeVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Adress = x.Adress,
                    AdressCity = x.City.Name,
                    Country = x.Country.Name,
                    MobileNumber = x.MobileNumber,
                    HomeNumber=x.HomeNumber,
                    BusinessNumber = x.BusinessNumber,
                    Nationality = x.Nationality,
                    HomeTown = x.HomeTown,
                    IdentificationNumber = x.IdentificationNumber,
                    BirthDate = x.BirthDate,
                    BloodType = x.BloodType,
                    MaritalStatu = x.MaritalStatu,
                    Gender = x.Gender,
                    Position = x.Position,
                    HospitalAndClinic = x.HospitalAndClinic.Hospital.Name + " " + x.HospitalAndClinic.Clinic.Name}).ToList();
            return View(applicationDbContext);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Country)
                .Include(e => e.HospitalAndClinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Name");
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Name");
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x=>x.Hospital).Include(x=>x.Clinic).Select(x=>new { Id= x.Id, Name = x.Hospital.Name + " "+x.Clinic.Name  }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,HospitalAndClinicId,Id,FirstName,LastName,Adress,AdressCity,MobileNumber,HomeNumber,BusinessNumber,Nationality,HomeTown,IdentificationNumber,BirthDate,Gender,MaritalStatu,BloodType")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Id", employee.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Id", employee.Nationality);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", employee.HospitalAndClinicId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Id", employee.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Id", employee.Nationality);
            var hospitalAndClinic = _context.HospitalAndClinic.Include(x => x.Hospital).Include(x => x.Clinic).Select(x => new { Id = x.Id, Name = x.Hospital.Name + " " + x.Clinic.Name }).ToList();
            ViewData["HospitalAndClinicId"] = new SelectList(hospitalAndClinic, "Id", "Name");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Position,HospitalAndClinicId,Id,FirstName,LastName,Adress,AdressCity,MobileNumber,HomeNumber,BusinessNumber,Nationality,HomeTown,IdentificationNumber,BirthDate,Gender,MaritalStatu,BloodType")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["HomeTown"] = new SelectList(_context.City, "Id", "Id", employee.HomeTown);
            ViewData["Nationality"] = new SelectList(_context.Country, "Id", "Id", employee.Nationality);
            ViewData["HospitalAndClinicId"] = new SelectList(_context.HospitalAndClinic, "Id", "Id", employee.HospitalAndClinicId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Country)
                .Include(e => e.HospitalAndClinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

    }
    
}
