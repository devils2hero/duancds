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
    public class AnswerController : Controller
    {
        private readonly IAnswerService _AnswerService;
        public AnswerController(IAnswerService _AnswerService)
        {
            this._AnswerService = _AnswerService;
        }
        

        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_AnswerService.GetAll());
        }
        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_AnswerService.GetById(_id));
        }
        //Create 
        [HttpPost]
        public JsonResult Create([FromBody]Answer obj)
        {
            return Json(_AnswerService.Create(obj));
        }
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id, [FromBody]Answer obj)
        {
            return Json(_AnswerService.Update(_id, obj));
        }

        //Delete
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_AnswerService.Delete(_id));
        }
    }
}