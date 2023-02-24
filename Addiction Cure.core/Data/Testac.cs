using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.Data
{
    public partial class Testac
    {
        public Testac()
        {
            Resulttsetacs = new HashSet<Resulttsetac>();
        }

        public decimal Testid { get; set; }
        public string Quastion { get; set; }
        public string Status { get; set; }
        public decimal? Patientid { get; set; }

        public virtual Patientac Patient { get; set; }
        public virtual ICollection<Resulttsetac> Resulttsetacs { get; set; }
    }
}
