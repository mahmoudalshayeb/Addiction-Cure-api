using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.Data
{
    public partial class Testac
    {
        public decimal Testid { get; set; }
        public decimal? Status { get; set; }
        public decimal? Patientid { get; set; }
        public decimal? Quastionid { get; set; }

        public virtual Patientac Patient { get; set; }
        public virtual Quastionsac Quastion { get; set; }
    }
}
