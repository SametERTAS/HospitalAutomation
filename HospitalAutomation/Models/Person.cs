using HospitalAutomation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Adress { get; set; }
        [Display(Name = "Adress City")]
        public string AdressCity { get; set; }
        [Display(Name ="Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name ="Home Number")]
        public string HomeNumber { get; set; }
        [Display(Name = "Business Number")]
        public string BusinessNumber { get; set; }
        public int Nationality { get; set; }
        public int HomeTown { get; set; }
        [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]

        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Display(Name ="Marital Statu")]
        public MaritalStatu MaritalStatu { get; set; }
        [Display(Name ="Blood Type")]
        public BloodType BloodType { get; set; }
        [ForeignKey("HomeTown")]
        public City City { get; set; }
      //  [ForeignKey("Nationality")]
        public Country Country { get; set; }

    }
}
