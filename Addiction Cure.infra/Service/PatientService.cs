using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepostory ipatientRepostory;
        public PatientService(IPatientRepostory ipatientRepostory)
        {
            this.ipatientRepostory = ipatientRepostory;
        }

        //Get all patient
        public List<Patientac> GetAllPatient()
        {
            return ipatientRepostory.GetAllPatient();
        }

        //Create Patient
        public void createpatient(Patientac patient)
        {
            ipatientRepostory.createpatient(patient);
        }

        //Update Patient
        public void updatepatient(Patientac patient)
        {
            ipatientRepostory.updatepatient(patient);
        }

        //delete
        public void Delete(int patientid)
        {
            ipatientRepostory.Delete(patientid);
        }
    }
}
