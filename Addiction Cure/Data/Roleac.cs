﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Addiction_Cure.Data
{
    public partial class Roleac
    {
        public Roleac()
        {
            Loginacs = new HashSet<Loginac>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Loginac> Loginacs { get; set; }
    }
}