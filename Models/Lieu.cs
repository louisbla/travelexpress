using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Lieu
    {
        public Lieu()
        {
            Participation = new HashSet<Participation>();
        }

        public int SalleId { get; set; }
        public string Libelle { get; set; }
        public byte? Occupe { get; set; }
        public byte? Visible { get; set; }

        public ICollection<Participation> Participation { get; set; }
    }
}
