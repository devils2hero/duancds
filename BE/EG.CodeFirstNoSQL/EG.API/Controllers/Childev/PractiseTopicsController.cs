using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EG.Model.Models.Childev;
using EG.Service.Childev;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EG.API.Controllers.Childev
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractiseTopicsController : Controller
    {
        private readonly IPractiseTopic _PractiseTopic;
        public PractiseTopicsController(IPractiseTopic _PractiseTopic)
        {
            this._PractiseTopic = _PractiseTopic;
        }

        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_PractiseTopic.GetAll());
        }
        
        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_PractiseTopic.GetById(_id));
        }

        //Create
        [HttpPost]
        public JsonResult Create([FromBody]PractiseTopic obj)
        {
            return Json(_PractiseTopic.Create(obj));
        }

        [HttpPut("{_id}")]
        public JsonResult Update(string _id, [FromBody]PractiseTopic obj)
        {
            return Json(_PractiseTopic.Update(_id,obj));
        }

        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_PractiseTopic.Delete(_id));
        }
    }
}