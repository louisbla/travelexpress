using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class DocumentOfficiel
    {
        public int DocumentId { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public int DossierId { get; set; }
        public byte? Visible { get; set; }

        public DossierInscription Dossier { get; set; }
    }
}
