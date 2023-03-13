using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IAboutUsService
    {
        List<Aboutusac> GetAllAboutUs();
        void createAboutUs(Aboutusac aboutusac);
        void updateAboutUs(Aboutusac aboutusac);
        void DeleteAboutUs(int aboutusid);
    }
}
