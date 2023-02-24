using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.Data
{
    public partial class Categoryac
    {
        public Categoryac()
        {
            Addictionsacs = new HashSet<Addictionsac>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Image { get; set; }
        public string Abouttext { get; set; }

        public virtual ICollection<Addictionsac> Addictionsacs { get; set; }
    }
}
