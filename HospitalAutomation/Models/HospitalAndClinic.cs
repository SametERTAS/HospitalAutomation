using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class HospitalAndClinic
    {
        public int Id { get; set; }
        [Display(Name ="Hospital")]
        public int HospitalId { get; set; }
        [Display(Name="Clinic")]
        public int ClinicId { get; set; }
        [ForeignKey("HospitalId")]
        public Hospital Hospital { get; set; }
        [ForeignKey("ClinicId")]
        public Clinic Clinic { get; set; }

        


    }
}
