using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class StatutFacture
    {
        public StatutFacture()
        {
            Factures = new HashSet<Facture>();
        }

        public int StatutFactureId { get; set; }
        public string Libelle { get; set; }

        public ICollection<Facture> Factures { get; set; }
    }
}
