using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garderie.Models
{
    public partial class ContactUrgence
    {
        public ContactUrgence()
        {
        }

        [ForeignKey(nameof(Personne))]
        public int ContactId { get; set; }
        public string Telephone { get; set; }

        public Personne Contact { get; set; }
        public Personne Personne { get; internal set; }
    }
}
