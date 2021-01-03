using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class ExaminationAndTest
    {
        public int Id { get; set; }
        [Display(Name="Examination")]
        public int ExaminationId { get; set; }
        [Display(Name="Test")]
        public int TestId { get; set; }
        [ForeignKey("ExaminationId")]
        public Examination Examination { get; set; }
        [ForeignKey("TestId")]
        public Test Test { get; set; }
    }
}
