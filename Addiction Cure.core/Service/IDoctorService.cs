using Addiction_Cure.core.data;
using Addiction_Cure.core.DTO;
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
        List<SearchByName> GetDocByName(string thename);
        List<Register> getbyid(int id);
    }
}
