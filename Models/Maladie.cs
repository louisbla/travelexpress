using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Maladie
    {
        public Maladie()
        {
            Traitements = new HashSet<Traitement>();
        }

        public int MaladieId { get; set; }
        public string Nom { get; set; }
        public string Descriptif { get; set; }
        public byte? Visible { get; set; }

        public ICollection<Traitement> Traitements { get; set; }
    }
}
