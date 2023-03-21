using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.DTO
{
    public class Report
    { 
        public string Patientfname { get; set; } 
        public string Patientlname { get; set; } 
        public string Dcotorfname { get; set; } 
        public string Doctorlname { get; set; } 
        public int amount { get; set; }
        public int numberoftest { get; set; }
        public DateTime datetest { get; set; }
    }
}
