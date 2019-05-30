using System;
using System.ComponentModel.DataAnnotations;
using Garderie.Models;

namespace Garderie.ViewModels.EnfantViewModels
{
    public class EditEnfantViewModel
    {
        public int EnfantId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Required]
        public string Sexe { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaissance { get; set; }
        [Required]
        [Display(Name = "Numéro de sécurité sociale")]
        public string NumSecu { get; set; }
        public Groupe Groupe { get; set; }
        public string Photo { get; set; }
    }
}
