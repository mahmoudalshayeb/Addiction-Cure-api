﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.data
{
    public partial class Patientac
    {
        public Patientac()
        {
            Testacs = new HashSet<Testac>();
        }

        public decimal Patientid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Imagename { get; set; }
        public string Level1 { get; set; }
        public decimal? Doctodid { get; set; }
        public decimal? Loginid { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Categoryac Category { get; set; }
        public virtual Dictorac Doctod { get; set; }
        public virtual Loginac Login { get; set; }
        public virtual ICollection<Testac> Testacs { get; set; }
    }
}
