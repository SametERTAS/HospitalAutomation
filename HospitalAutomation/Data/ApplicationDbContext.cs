using HospitalAutomation.Models;
using HospitalAutomation.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAutomation.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<HospitalAndClinic> HospitalAndClinic { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Examination> Examination { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<PrescriptionAndMedicine> PrescriptionAndMedicine { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<ExaminationAndTest> ExaminationAndTest { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasOne(x => x.HospitalAndClinic).WithMany().HasForeignKey(x => x.HospitalAndClinicId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Employee>().HasOne(x => x.HospitalAndClinic).WithMany().HasForeignKey(x => x.HospitalAndClinicId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Appointment>().HasOne(x => x.HospitalAndClinic).WithMany().HasForeignKey(x => x.HospitalAndClinicId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Appointment>().HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Doctor>().HasOne(x => x.Country).WithMany().HasForeignKey(x => x.Nationality).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Patient>().HasOne(x => x.Country).WithMany().HasForeignKey(x => x.Nationality).OnDelete(DeleteBehavior.NoAction).IsRequired();
            modelBuilder.Entity<Employee>().HasOne(x => x.Country).WithMany().HasForeignKey(x => x.Nationality).OnDelete(DeleteBehavior.NoAction).IsRequired();



        }
    }
}
