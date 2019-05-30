using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garderie.Models;

namespace Garderie.ViewModels.ParentViewModels
{
    public class DetailsParentViewModel
    {
        public DetailsParentViewModel()
        {
            Filiations = new HashSet<Enfant>();
        }
        public int ParentId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }

        [Display(Name = "Date de naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaissance { get; set; }

        [Display(Name = "Numéro de sécurité sociale")]
        public string NumSecu { get; set; }

        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        public ICollection<Enfant> Filiations { get; set; }
    }
}
