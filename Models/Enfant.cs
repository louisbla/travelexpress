using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garderie.Models
{
    public class Enfant
    {
        public Enfant()
        {
            DossiersInscription = new HashSet<DossierInscription>();
            Filiations = new HashSet<Filiation>();
            Traitements = new HashSet<Traitement>();
        }

        [ForeignKey(nameof(Personne))]
        public int EnfantId { get; set; }
        public string Photo { get; set; }
        public int GroupeId { get; set; }
        public int InventaireEnfantId { get; set; }

        public Personne Personne { get; set; }
        public Groupe Groupe { get; set; }
        public InventaireEnfant InventaireEnfant { get; set; }
        public ICollection<DossierInscription> DossiersInscription { get; set; }
        public ICollection<Filiation> Filiations { get; set; }
        public ICollection<Traitement> Traitements { get; set; }
    }
}
