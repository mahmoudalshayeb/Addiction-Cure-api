using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IDoctorService
    {
        List<Dictorac> GetAlldoctor();
        void createdoctor(Dictorac doctor);
        void updatedoctor(Dictorac doctor);
        void Deletedoctor(int doctorid);
    }
}
