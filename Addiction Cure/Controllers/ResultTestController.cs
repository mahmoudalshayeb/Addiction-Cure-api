using Addiction_Cure.core.data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultTestController : ControllerBase
    {
        private readonly IResultTestService resultTestService;

        public ResultTestController(IResultTestService resultTestService)
        {
            this.resultTestService = resultTestService;
        }


        [HttpGet]
        public List<Resulttsetac> GetAllResult()
        {
            return resultTestService.GetAllResult();
        }

        [HttpPost]
        public void CreateResult(Resulttsetac result)
        {
            resultTestService.CreateResult(result);
        }

        [HttpPut]
        public void UpdateResult(Resulttsetac result)
        { 
            resultTestService.UpdateResult(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteResult(int id ) {
        resultTestService.DeleteResult(id);
        }

        [HttpGet]
        [Route("{datefrom}/{dateto}")]
        public List<Resulttsetac> GetResultBetween(DateTime datefrom, DateTime dateto)
        {
            return resultTestService.GetResultBetween(datefrom, dateto);
        }
    }
}
