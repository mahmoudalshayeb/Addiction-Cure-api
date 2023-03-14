using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.Data
{
    public partial class Resulttsetac
    {
        public decimal Resulttestid { get; set; }
        public string Resulttest { get; set; }
        public string Perioddate { get; set; }
        public string Description { get; set; }
        public decimal? Numberoftest { get; set; }
        public DateTime? Datetest { get; set; }
        public decimal? Testid { get; set; }
        public decimal? Doctodid { get; set; }

        public virtual Dictorac Doctod { get; set; }
        public virtual Testac Test { get; set; }
    }
}
