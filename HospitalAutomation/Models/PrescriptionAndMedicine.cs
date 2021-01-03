using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class PrescriptionAndMedicine
    {
        public int Id { get; set; }
        [Display(Name="Prescription")]
        public int PrescriptionId { get; set; }
        [Display(Name="Medicine")]
        public int MedicineId { get; set; }

        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
    }
}
