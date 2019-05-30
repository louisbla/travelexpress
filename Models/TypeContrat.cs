using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class TypeContrat
    {
        public TypeContrat()
        {
            DossiersEmploye = new HashSet<DossierEmploye>();
        }

        public int TypeContratId { get; set; }
        public string Libelle { get; set; }

        public ICollection<DossierEmploye> DossiersEmploye { get; set; }
    }
}
