using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface ILoginRepository
    {
        Loginac register(Loginac login);
        Loginac login(Loginac login);
    }
}
