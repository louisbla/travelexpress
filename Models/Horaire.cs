using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Horaire
    {
        public int HoraireId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? HeureDebut { get; set; }
        public TimeSpan? HeureFin { get; set; }
        public int CalendrierId { get; set; }
        public byte? Visible { get; set; }
        public int EmployeId { get; set; }

        public Calendrier Calendrier { get; set; }
    }
}
