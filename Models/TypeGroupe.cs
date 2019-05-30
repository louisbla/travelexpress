using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class TypeGroupe
    {
        public TypeGroupe()
        {
            Groupes = new HashSet<Groupe>();
        }

        public int TypeGroupeId { get; set; }
        public string Libelle { get; set; }

        public ICollection<Groupe> Groupes { get; set; }
    }
}
