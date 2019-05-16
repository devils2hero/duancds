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
    public class TopicController : Controller
    {
        private readonly ITopicService _TopicService;
        public TopicController(ITopicService _TopicService)
        {
            this._TopicService = _TopicService;
        }
        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_TopicService.GetAll());
        }
        
        //GetByID
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_TopicService.GetById(_id));
        }
        //Create
        [HttpPost]
        public JsonResult Post([FromBody]Topic obj)
        {
            return Json(_TopicService.Create(obj));
        }
        //Update
        
        [HttpPut("{_id}")]
        public JsonResult Put(string _id,[FromBody]Topic obj)
        {
            return Json(_TopicService.Update(_id, obj));
        }

        //Delete
        [HttpGet("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_TopicService.Delete(_id));
        }
    }
}