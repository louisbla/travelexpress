using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class ObjetFacturable
    {
        public ObjetFacturable()
        {
            LignesFactures = new HashSet<LigneFacture>();
        }

        public int ObjetFacturableId { get; set; }
        public double? PrixHt { get; set; }
        public string Nom { get; set; }
        public int Tvaid { get; set; }
        public int? ActiviteId { get; set; }
        public byte? Visible { get; set; }

        public Activite Activite { get; set; }
        public Tva Tva { get; set; }
        public ICollection<LigneFacture> LignesFactures { get; set; }
    }
}
