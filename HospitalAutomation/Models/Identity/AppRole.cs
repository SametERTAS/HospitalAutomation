using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Models.Identity
{
    public class AppRole:IdentityRole<string>
    {
        public DateTime CreateDate { get; set; }
    }
}
