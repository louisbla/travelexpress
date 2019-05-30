using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Adresse
    {
        public Adresse()
        {
            PersonneAdresses = new HashSet<PersonneAdresse>();
        }

        public int AdresseId { get; set; }
        public string Ligne1 { get; set; }
        public string Ligne2 { get; set; }
        public string Ligne3 { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Pays { get; set; }
        public byte? Visible { get; set; }

        public ICollection<PersonneAdresse> PersonneAdresses { get; set; }
    }
}
