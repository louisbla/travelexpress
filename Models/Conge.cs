using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Conge
    {
        public int CongeId { get; set; }
        public DateTime? Debut { get; set; }
        public int? Duree { get; set; }
        public int TypeCongeId { get; set; }
        public byte? Visible { get; set; }
        public int DossierEmployeId { get; set; }

        public DossierEmploye DossierEmploye { get; set; }
        public TypeConge TypeConge { get; set; }
    }
}
