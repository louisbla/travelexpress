using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class DossierEmploye
    {
        public DossierEmploye()
        {
            Conges = new HashSet<Conge>();
            FichesPaye = new HashSet<FichePaye>();
        }

        public int DossierId { get; set; }
        public DateTime? DateEntree { get; set; }
        public int? NbMoisAnciennete { get; set; }
        public double? TauxHoraireBrut { get; set; }
        public byte? Visible { get; set; }
        public int TypeContratId { get; set; }
        public int EmployeId { get; set; }

        public Employe Employe { get; set; }
        public TypeContrat TypeContrat { get; set; }
        public ICollection<Conge> Conges { get; set; }
        public ICollection<FichePaye> FichesPaye { get; set; }
    }
}
