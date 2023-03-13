using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IPatientRepostory
    {
        List<Patientac> GetAllPatient();
        void createpatient(Patientac patient);
        void Delete(int patientid);
        void updatepatient(Patientac patient);
    }
}
