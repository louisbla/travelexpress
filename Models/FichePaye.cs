using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class FichePaye
    {
        public int FichePayeId { get; set; }
        public double SalaireBrut { get; set; }
        public double NbHeuresPrevu { get; set; }
        public double NbHeuresReel { get; set; }
        public int DossierEmployeId { get; set; }
        public byte Visible { get; set; }

        public DossierEmploye DossierEmploye { get; set; }
    }
}
