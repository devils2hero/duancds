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
    public class QuestionReportController : Controller
    {
        private readonly IQuestionReport _QuestionReport;
        public QuestionReportController(IQuestionReport _QuestionReport)
        {
            this._QuestionReport = _QuestionReport;
        }

        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_QuestionReport.GetAll());
        }
        
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_QuestionReport.GetById(_id));
        }

        [HttpPost]
        public JsonResult Create([FromBody]QuestionReport obj)
        {
            return Json(_QuestionReport.Create(obj));
        }
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id, [FromBody]QuestionReport obj)
        {
            return Json(_QuestionReport.Update(_id,obj));
        }

        //Delete
        [HttpGet("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_QuestionReport.Delete(_id));
        }
    }
}