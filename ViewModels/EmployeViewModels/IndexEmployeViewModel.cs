using System;
using System.ComponentModel.DataAnnotations;

namespace Garderie.ViewModels.EmployeViewModels
{
    public class IndexEmployeViewModel
    {
        public int EmployeId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Poste { get; set; }
        [Display(Name = "Date de naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaissance { get; set; }
        [Display(Name = "Numéro de sécurité sociale")]
        public string NumSecu { get; set; }
        public string Telephone { get; set; }
        public string Externe { get; set; }
    }
}
