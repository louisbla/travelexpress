using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garderie.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Filiations = new HashSet<Filiation>();
            ParentsFactures = new HashSet<ParentFacture>();
        }

        [ForeignKey(nameof(Personne))]
        public int ParentId { get; set; }
        public int? NbEnfantsInscrits { get; set; }
        public string Telephone { get; set; }

        public Personne Personne { get; set; }
        public ICollection<Filiation> Filiations { get; set; }
        public ICollection<ParentFacture> ParentsFactures { get; set; }
    }
}
