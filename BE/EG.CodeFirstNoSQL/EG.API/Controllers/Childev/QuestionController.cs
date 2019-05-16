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
    public class QuestionController : Controller
    {
        //contrustor 
        private readonly IQuestionService _QuestionService;
        public QuestionController(IQuestionService _QuestionService)
        {
            this._QuestionService = _QuestionService;
        }
        //Get ALL
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_QuestionService.GetAll());
        }
        //GetByID
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_QuestionService.GetById(_id));
        }
        //Create

        [HttpPost]
        public JsonResult Create([FromBody]Question obj)
        {
            return Json(_QuestionService.Create(obj));
        }
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]Question obj)
        {
            return Json(_QuestionService.Update(_id, obj));
        }
        //Delete
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_QuestionService.Delete(_id));
        }
    }
}