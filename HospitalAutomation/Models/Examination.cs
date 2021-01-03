using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Examination
    {
        [Display(Name="Appointment")]
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        [ForeignKey("Id")]
        public Appointment Appointment { get; set; }



        public Prescription Prescription { get; set; }
    }
}
