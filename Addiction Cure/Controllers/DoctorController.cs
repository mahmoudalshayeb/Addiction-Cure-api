using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService idoctorService;
        public DoctorController(IDoctorService idoctorService)
        {
            this.idoctorService = idoctorService;
        }

        [HttpGet]
        [Route("getalldoctor")]
        public List<Dictorac> GetAlldoctor()
        {
            return idoctorService.GetAlldoctor();
        }

        [HttpPost]
        [Route("createdoctor")]
        public void createdoctor(Dictorac doctor)
        {
            idoctorService.createdoctor(doctor);
        }

        [HttpPut]
        [Route("updatedoctor")]
        public void updatedoctor(Dictorac doctor)
        {
            idoctorService.updatedoctor(doctor);
        }

        [HttpPost]
        [Route("deletedoctor/{doctorid}")]
        public void Deletedoctor(int doctorid)
        {
            idoctorService.Deletedoctor(doctorid);
        }
    }
}
