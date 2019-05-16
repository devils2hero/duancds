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
    public class EventController : Controller
    {
        private readonly IEventService _EventService;
        public EventController(IEventService _EventService)
        {
            this._EventService = _EventService;
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_EventService.GetAll());
        }

        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_EventService.GetById(_id));
        }
        [HttpPost]
        public JsonResult Create([FromBody]Event obj)
        {
            return Json(_EventService.Create(obj));
        }
        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]Event obj)
        {
            return Json(_EventService.Update(_id, obj));
        }
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_EventService.Delete(_id));
        }
        

    }
}