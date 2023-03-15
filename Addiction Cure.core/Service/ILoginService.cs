using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface ILoginService
    {
        String Login(Loginac login);
        Register register(Register patient);
        DoctorRegister DoctorRegister(DoctorRegister doctorRegister);

    }
}
