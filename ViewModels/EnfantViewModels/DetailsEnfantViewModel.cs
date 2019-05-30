using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garderie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garderie.ViewModels.EnfantViewModels
{
    public class DetailsEnfantViewModel
    {
        public DetailsEnfantViewModel()
        {
            Filiations = new HashSet<Parent>();
            //DossierContactUrgences = new HashSet<DossierContactUrgence>();
        }

        public int EnfantId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaissance { get; set; }
        [Display(Name = "Numéro de sécurité sociale")]
        public string NumSecu { get; set; }

        public string Photo { get; set; }
        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public ICollection<Parent> Filiations { get; set; }
       //public ICollection<DossierContactUrgence> DossierContactUrgences { get; set; }

    }
}
