using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class ParentFacture
    {
        public int FactureId { get; set; }
        public int ParentId { get; set; }
        public int Visible { get; set; }

        public Facture Facture { get; set; }
        public Parent Parent { get; set; }
    }
}
