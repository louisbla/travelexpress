using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Calendrier
    {
        public Calendrier()
        {
            Horaires = new HashSet<Horaire>();
        }

        public int CalendrierId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int EmployeId { get; set; }
        public byte? Visible { get; set; }

        public Employe Employe { get; set; }
        public ICollection<Horaire> Horaires { get; set; }
    }
}
