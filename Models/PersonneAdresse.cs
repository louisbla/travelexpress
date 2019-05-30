using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class PersonneAdresse
    {
        public int AdresseId { get; set; }
        public int PersonneId { get; set; }
        public byte? Domicile { get; set; }
        public byte? Facturation { get; set; }
        public byte Visible { get; set; }

        public Adresse Adresse { get; set; }
        public Personne Personne { get; set; }
    }
}
