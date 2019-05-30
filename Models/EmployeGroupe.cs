using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class EmployeGroupe
    {
        public int GroupeId { get; set; }
        public int EmployeId { get; set; }

        public Employe Employe { get; set; }
        public Groupe Groupe { get; set; }
    }
}
