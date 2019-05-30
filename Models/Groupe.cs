using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garderie.Models
{
    public partial class Groupe
    {
        public Groupe()
        {
            Visible = 1;
            EmployeGroupes = new HashSet<EmployeGroupe>();
            Enfants = new HashSet<Enfant>();
            Participation = new HashSet<Participation>();
        }

        public int GroupeId { get; set; }
        public string Descriptif { get; set; }
        public int? ReferantId { get; set; }
        public byte? Visible { get; set; }
        public int TypeGroupeId { get; set; }

        public Employe Referant { get; set; }
        public TypeGroupe TypeGroupe { get; set; }
        public ICollection<EmployeGroupe> EmployeGroupes { get; set; }
        public ICollection<Enfant> Enfants { get; set; }
        public ICollection<Participation> Participation { get; set; }
    }
}
