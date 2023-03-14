using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.Data
{
    public partial class Testemonialac
    {
        public decimal Tesemonialid { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public string Messageuser { get; set; }
        public decimal? Patientid { get; set; }
    }
}
