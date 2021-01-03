using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace HospitalAutomation.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Display()]
        public string  Name { get; set; }
        [Display(Name ="Phone Code")]
        public int PhoneCode { get; set; }
    }
}
