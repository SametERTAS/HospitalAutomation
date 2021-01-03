using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.ViewModels.PrescriptionAndMedicine
{
    public class PrescriptionAndMedicineVM
    {
        public int Id { get; set; }
        [Display(Name="Prescription Info")]
        public string PrescriptionInfo { get; set; }
        [Display(Name="Medicine Name")]
        public string MedicineName { get; set; }
    }
}
