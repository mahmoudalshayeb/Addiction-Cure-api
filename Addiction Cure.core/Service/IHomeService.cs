using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IHomeService
    {
        List<Homepageac> GetAllhome();
        void createhome(Homepageac homepageac);
        void updatehome(Homepageac homepageac);
        void Deletehome(int id);
    }
}
