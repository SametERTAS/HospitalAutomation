using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.ViewModels.Appointment
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        [Display(Name="Patient")]
        public string PatientFullName { get; set; }
        [Display(Name = "Doctor")]
        public string DoctorFullName { get; set; }
        [Display(Name = "Hospital")]
        public string HospitalAndClinic { get; set; }
        public DateTime Time { get; set; }
    }
}
