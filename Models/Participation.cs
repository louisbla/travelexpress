using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Participation
    {
        public DateTime Date { get; set; }
        public int ActiviteId { get; set; }
        public int GroupeId { get; set; }
        public int SalleId { get; set; }
        public byte Visible { get; set; }

        public Activite Activite { get; set; }
        public Groupe Groupe { get; set; }
        public Lieu Salle { get; set; }
    }
}
