using System;
using Microsoft.AspNetCore.Identity;

namespace Garderie.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Access { get; set; }
    }
}
