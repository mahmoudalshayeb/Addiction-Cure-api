using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Addiction_Cure.core.Service
{
    public interface IPatientService
    {
        List<Patientac> GetAllPatient();
        void createpatient(Patientac patient);
        void Delete(int patientid);
        void updatepatient(Patientac patient);
    }
}