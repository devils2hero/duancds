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
    public class CourseController : Controller
    {
        private readonly ICourseService _CourseService;
        public CourseController(ICourseService _CourseService)
        {
            this._CourseService = _CourseService;
        }
        // Post : api/Course
        [HttpPost]
        public JsonResult Post([FromBody]Course obj)
        {
            return Json(_CourseService.Create(obj));
        }

        //Put: api/Course/id
        [HttpPut("{_id}")]
        public JsonResult Put(string _id, [FromBody]Course obj)
        {
            return Json(_CourseService.Update(_id, obj));
        }

        //Delete 
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_CourseService.Delete(_id));
        }
      
        //GetAll 
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_CourseService.GetAll());
        }
        
        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_CourseService.GetById(_id));
        }
    }
}