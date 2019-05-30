using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Garderie.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int? PersonneId { get; set; }
        public byte? Visible { get; set; }

        public Personne Personne { get; set; }
    }
}
