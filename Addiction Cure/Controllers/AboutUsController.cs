using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Addiction_Cure.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            this.aboutUsService = aboutUsService;
        }
        [HttpGet]
        [Route("getallAboutUs")]
        public List<Aboutusac> GetAllAboutUs()
        {
           
            return aboutUsService.GetAllAboutUs();
        }

        [HttpPost]
        [Route("createAboutUs")]
        public void createAboutUs(Aboutusac aboutusac)
        {
            aboutUsService.createAboutUs(aboutusac);
        }

        [HttpPut]
        [Route("updateAboutUs")]
        public void updateAboutUs(Aboutusac aboutusac)
        {
            aboutUsService.updateAboutUs(aboutusac);
        }

        [HttpPost]
        [Route("deleteAboutUs/{Aboutusid}")]
        public void DeleteAboutUs(int aboutusid)
        {
            aboutUsService.DeleteAboutUs(aboutusid);
        }
    }
}
