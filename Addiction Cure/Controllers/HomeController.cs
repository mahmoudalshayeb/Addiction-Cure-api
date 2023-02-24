using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [HttpGet]
        [Route("getallHome")]
        public List<Homepageac> GetAllHome()
        {
            return homeService.GetAllhome();
        }

        [HttpPost]
        [Route("createHome")]
        public void createhome(Homepageac homepageac)
        {
            homeService.createhome(homepageac);
        }

        [HttpPut]
        [Route("updateHome")]
        public void updatehome(Homepageac homepageac)
        {
            homeService.updatehome(homepageac);
        }

        [HttpPost]
        [Route("deleteHome/{hid}")]
        public void DeleteHome(int hid)
        {
            homeService.Deletehome(hid);
        }
    }
}

