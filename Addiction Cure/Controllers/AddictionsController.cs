using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

//// mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddictionsController : ControllerBase
    {

        private readonly IAddictionService _addictionService;



        public AddictionsController(IAddictionService addictionService)
        {
            _addictionService = addictionService;
        }




        // IMPLEMENTAION OF  GetAllAddictionsAC



        [HttpGet]
        public List<Addictionsac> GetAllAddictionsAC()
        {
            return _addictionService.GetAllAddictionsAC();
        }





        // IMPLEMENTAION OF  GetAddictionByIdAC

        [HttpGet]
        [Route("getById/{id}")]
        public Addictionsac GetAddictionByIdAC(int id)
        {
            return _addictionService.GetAddictionByIdAC(id);
        }





        // IMPLEMENTAION OF  CreateAddictionAC

        [HttpPost]
        [Route("Create")]
        public void CreateAddictionAC(Addictionsac addictionsac)
        {
            _addictionService.CreateAddictionAC(addictionsac);
        }




        // IMPLEMENTAION OF  UpdateAddictionAC

        [HttpPut]
        [Route("Update")]
        public void UpdateAddictionAC(Addictionsac addictionsac)
        {
            _addictionService.UpdateAddictionAC(addictionsac);
        }




        // IMPLEMENTAION OF  DeleteAddictionAC

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteAddictionAC(int id)
        {
            _addictionService.DeleteAddictionAC(id);
        }




        [HttpPost]
        [Route("uploadImage")]
        public Addictionsac UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);


            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // its like insert TEMPORARY record from category all ATTRIBUTS  are null except the image 

            Addictionsac item = new Addictionsac();
            item.Image = fileName;
            return item;
        }

    }
}
