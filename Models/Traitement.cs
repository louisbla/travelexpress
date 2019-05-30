using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Traitement
    {
        public int MaladieId { get; set; }
        public int EnfantId { get; set; }
        public string NomMedicament { get; set; }
        public string Specification { get; set; }
        public string Type { get; set; }
        public double? Quantite { get; set; }
        public int? Frequence { get; set; }
        public byte Visible { get; set; }

        public Enfant Enfant { get; set; }
        public Maladie Maladie { get; set; }
    }
}
