using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Employee : Person
    {
        public string Position { get; set; }
        [Display(Name="Clinics in Hospital")]
        public int HospitalAndClinicId { get; set; }
        [ForeignKey("HospitalAndClinicId")]
        public HospitalAndClinic HospitalAndClinic { get; set; }
    }
}
