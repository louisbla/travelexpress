using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garderie.Models
{
    public partial class Employe
    {
        public Employe()
        {
            Calendriers = new HashSet<Calendrier>();
            DossiersEmploye = new HashSet<DossierEmploye>();
            EmployeGroupes = new HashSet<EmployeGroupe>();
            Groupes = new HashSet<Groupe>();
            Inventaires = new HashSet<Inventaire>();
        }

        [ForeignKey(nameof(Personne))]
        public int EmployeId { get; set; }
        public string Poste { get; set; }
        public byte? Externe { get; set; }
        public string Telephone { get; set; }

        public Personne Personne { get; set; }
        public ICollection<Calendrier> Calendriers { get; set; }
        public ICollection<DossierEmploye> DossiersEmploye { get; set; }
        public ICollection<EmployeGroupe> EmployeGroupes { get; set; }
        public ICollection<Groupe> Groupes { get; set; }
        public ICollection<Inventaire> Inventaires { get; set; }
    }
}
