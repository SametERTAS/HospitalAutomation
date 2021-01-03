using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.ViewModels.Prescription
{
    public class PrescriptionVM
    {
        public int Id { get; set; }
        [Display(Name="Prescription Number")]
        public string PrescriptionNumber { get; set; }
        public DateTime Time { get; set; }
        public string Examination { get; set; }
    }
}
