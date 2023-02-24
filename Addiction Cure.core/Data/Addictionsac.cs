using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.Data
{
    public partial class Addictionsac
    {
        public decimal Addictionid { get; set; }
        public string Addictionname { get; set; }
        public string Image { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Categoryac Category { get; set; }
    }
}
