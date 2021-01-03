using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "District")]
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
