using HospitalAutomation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.ViewModels.Employee
{
    public class EmployeeVM
    {
          
         public int Id { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Adress { get; set; }
        [Display(Name = "Adress City")]
        public string AdressCity { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Home Number")]
        public string HomeNumber { get; set; }
        [Display(Name = "Business Number")]
        public string BusinessNumber { get; set; }
        public int Nationality { get; set; }
        public int HomeTown { get; set; }
        [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Marital Statu")]
        public MaritalStatu MaritalStatu { get; set; }
        [Display(Name = "Blood Type")]
        public BloodType BloodType { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Position { get; set; }
        [Display(Name = "Hospital And Clinic")]

        public string HospitalAndClinic { get; set; }
         
         
    }
}
