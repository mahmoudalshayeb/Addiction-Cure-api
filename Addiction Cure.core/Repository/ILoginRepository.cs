using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface ILoginRepository
    {
        void register(Register patient);
        Loginac login(Loginac login);

        void DoctorRegister(DoctorRegister doctorRegister);
    }
}
