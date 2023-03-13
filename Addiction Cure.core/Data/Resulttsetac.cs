using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.core.data
{
    public partial class Resulttsetac
    {
        public decimal Resulttestid { get; set; }
        public string Resulttest { get; set; }
        public string Description { get; set; }
        public DateTime? Perioddate { get; set; }
        public decimal? Numberoftest { get; set; }
        public DateTime? Datetest { get; set; }
        public decimal? Doctodid { get; set; }
        public decimal? Testid { get; set; }
    }
}
