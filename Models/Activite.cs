using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Activite
    {
        public Activite()
        {
            ObjetsFacturables = new HashSet<ObjetFacturable>();
            Participations = new HashSet<Participation>();
        }

        public int ActiviteId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int? NbEnfantsMax { get; set; }
        public string Lieu { get; set; }
        public byte? Visible { get; set; }

        public ICollection<ObjetFacturable> ObjetsFacturables { get; set; }
        public ICollection<Participation> Participations { get; set; }
    }
}
