using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpress5.Models
{
    public class Preferences
    {
        public int Id { get; set; }
        [Display(Name = "J'accepte les fumeurs")]
        public bool PrefFumeur { get; set; }
        [Display(Name = "J'accepte les animaux")]
        public bool PrefAnimaux { get; set; }
        [Display(Name = "J'aime discuter")]
        public bool PrefDiscussion { get; set; }
        [Display(Name = "J'aime écouter de la musique")]
        public bool PrefMusique { get; set; }
    }
}