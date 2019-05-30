using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garderie.ViewModels.EnfantViewModels
{
    public class CreateEnfantViewModel
    {
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
        public SelectList Groupes { get; set; }
    }
}
