using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Display(Name = "Patient" )]
        public int PatientId { get; set; }
        public DateTime Time { get; set; }
        [Display(Name ="Clinics in Hospital")]
        public int HospitalAndClinicId { get; set; }
        [Display(Name ="Doctor")]
        public int DoctorId { get; set; }


       // [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
       // [ForeignKey("HospitalAndClinicId")]
        public HospitalAndClinic HospitalAndClinic { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }




        public Examination Examination { get; set; }

    }
}
