using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.Data
{
    public partial class Dictorac
    {
        public Dictorac()
        {
            Patientacs = new HashSet<Patientac>();
            Resulttsetacs = new HashSet<Resulttsetac>();
        }

        public decimal Doctodid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Imagename { get; set; }
        public string Level1 { get; set; }
        public decimal? Loginid { get; set; }

        public virtual Loginac Login { get; set; }
        public virtual ICollection<Patientac> Patientacs { get; set; }
        public virtual ICollection<Resulttsetac> Resulttsetacs { get; set; }
    }
}
