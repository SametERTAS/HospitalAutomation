using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.ViewModels.ExaminationAndTest
{
    public class ExaminationAndTestVM
    {
        public int Id { get; set; }
        [Display(Name="Patient Info")]
        public string PatientInfo { get; set; }
        [Display(Name="Test Name")]
        public string TestName { get; set; }
    }
}
