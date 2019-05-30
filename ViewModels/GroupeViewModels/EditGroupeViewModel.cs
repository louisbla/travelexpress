using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garderie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garderie.ViewModels.GroupeViewModels
{
    public class EditGroupeViewModel
    {
        public int GroupeId { get; set; }

        [Required]
        public String Descriptif { get; set; }
        [Required]
        public int Referant { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int TypeGroupe { get; set; }

        public SelectList Referants { get; set; }
        public SelectList TypesGroupe { get; set; }
    }
}
