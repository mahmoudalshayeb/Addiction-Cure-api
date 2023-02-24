using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService ipatientService;
        public PatientController(IPatientService ipatientService)
        {
            this.ipatientService = ipatientService;
        }

        [HttpGet]
        [Route("getallPatient")]
        public List<Patientac> GetAllPatient()
        {
            return ipatientService.GetAllPatient();
        }

        [HttpPost]
        [Route("createPatient")]
        public void createpatient(Patientac patient)
        {
            ipatientService.createpatient(patient);
        }

        [HttpPut]
        [Route("updatePatient")]
        public void updatepatient(Patientac patient)
        {
            ipatientService.updatepatient(patient);
        }

        [HttpPost]
        [Route("deletePatient/{patientid}")]
        public void Delete(int patientid)
        {
            ipatientService.Delete(patientid);
        }

    }
}
