using Addiction_Cure.core.data;
using Addiction_Cure.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface ILoginRepository
    {
        Register register(Register patient);
        Loginac login(Loginac login);
    }
}
