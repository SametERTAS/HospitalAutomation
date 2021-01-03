using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models.Identity
{
    public class AppUser : IdentityUser<string>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public string IdentificationNumber { get; set; }

        public DateTime BirthDate { get; set; }


    }
}
