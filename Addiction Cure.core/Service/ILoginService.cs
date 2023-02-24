using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface ILoginService
    {
        String Login(Loginac login);
        Loginac register(Loginac login);
    }
}
