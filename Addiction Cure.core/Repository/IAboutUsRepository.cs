using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IAboutUsRepository
    {
        List<Aboutusac> GetAllAboutUs();
        void createAboutUs(Aboutusac aboutusac);
        void updateAboutUs(Aboutusac aboutusac);
        void DeleteAboutUs(int aboutusid);
    }
}
