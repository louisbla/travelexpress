using System;
using System.ComponentModel.DataAnnotations;

namespace Garderie.ViewModels.GroupeViewModels
{
    public class DetailsGroupeViewModel
    {
        public int GroupeId { get; set; }
        public string Descriptif { get; set; }
        public string Referant { get; set; }
        [Display(Name = "Type")]
        public string TypeGroupe { get; set; }
    }
}
