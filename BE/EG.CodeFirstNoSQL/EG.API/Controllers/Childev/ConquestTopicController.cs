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
    public class ConquestTopicController : Controller
    {
        private readonly IConquestTopics _ConquestTopics;
        public ConquestTopicController(IConquestTopics _ConquestTopics)
        {
            this._ConquestTopics = _ConquestTopics;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_ConquestTopics.GetAll());
        }

        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_ConquestTopics.GetById(_id));
        }
        [HttpPost]
        public JsonResult Create([FromBody]ConquestTopic obj)
        {
            return Json(_ConquestTopics.Create(obj));
        }

        [HttpPut("{_id}")]
        public JsonResult Update(string _id, [FromBody]ConquestTopic obj)
        {
            return Json(_ConquestTopics.Update(_id, obj));
        }

        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_ConquestTopics.Delete(_id));
        }
    }
}