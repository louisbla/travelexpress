using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Filiation
    {
        public int ParentId { get; set; }
        public int EnfantId { get; set; }
        public string LienParente { get; set; }
        public byte Visible { get; set; }

        public Enfant Enfant { get; set; }
        public Parent Parent { get; set; }
    }
}
