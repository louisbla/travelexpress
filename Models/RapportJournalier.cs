using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class RapportJournalier
    {
        public int RapportId { get; set; }
        public DateTime Date { get; set; }
        public byte? Present { get; set; }
        public string Resume { get; set; }
        public byte? Visible { get; set; }
        public int DossierInscriptionId { get; set; }

        public DossierInscription DossierInscription { get; set; }
    }
}
