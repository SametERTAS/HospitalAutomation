using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Prescription
    {
       [Display(Name ="Appointment")]
        public int Id { get; set; }
        [Display(Name ="Presciption Number")]
        public string PrescriptionNumber { get; set; }
        [Display(Name ="Prescription Time")]
        public DateTime DateTime { get; set; }

        [ForeignKey("Id")]
        public Examination Examination { get; set; }
    }
}
