using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {

        private readonly ITestimonialsService _testimonialsService;





        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }

        // IMPLEMENTAION OF  GetAllTestimonialAC




        [HttpGet]
        public List<Testemonialac> GetAllTestimonialAC()
        {
            return _testimonialsService.GetAllTestimonialAC();
        }





        // IMPLEMENTAION OF  GetTestimonialByIdAC

        [HttpGet]
        [Route("GetTestimonialByPatienId/{id}")]
        public Testemonialac GetTestimonialByIdAC(int id)
        {
            return _testimonialsService.GetTestimonialByIdAC(id);
        }







        // IMPLEMENTAION OF  CreateTestimonialAC

        [HttpPost]
        [Route("Create")]
        public void CreateTestimonialAC(Testemonialac testemonialac)
        {
            _testimonialsService.CreateTestimonialAC(testemonialac);
        }







        // IMPLEMENTAION OF  UpdateTestimonialAC

        [HttpPut]
        [Route("Update")]
        public void UpdateTestimonialAC(Testemonialac testemonialac)
        {
            _testimonialsService.UpdateTestimonialAC(testemonialac);
        }







        // IMPLEMENTAION OF  DeleteTestimonialAC

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteTestimonialAC(int id)
        {
            _testimonialsService.DeleteTestimonialAC(id);
        }



        /// UPLOAD IMAGE

        [HttpPost]
        [Route("uploadImage")]
        public Testemonialac UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);


            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // its like insert TEMPORARY record from category all ATTRIBUTS  are null except the image 

            Testemonialac item = new Testemonialac();
            item.Image_Path = fileName;
            return item;
        }



    }
}
