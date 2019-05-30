using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Tva
    {
        public Tva()
        {
            ObjetsFacturables = new HashSet<ObjetFacturable>();
        }

        public int Tvaid { get; set; }
        public string Nom { get; set; }
        public double? Valeur { get; set; }
        public byte Visible { get; set; }

        public ICollection<ObjetFacturable> ObjetsFacturables { get; set; }
    }
}
