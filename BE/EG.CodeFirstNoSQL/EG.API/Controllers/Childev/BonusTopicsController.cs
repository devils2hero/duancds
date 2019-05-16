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
    public class BonusTopicsController : Controller
    {
        private readonly IBonusTopics _BonusTopic;
        public BonusTopicsController(IBonusTopics _BonusTopic)
        {
            this._BonusTopic = _BonusTopic;
        }

        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_BonusTopic.GetAll());
        }

        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_BonusTopic.GetById(_id));
        }

        //Create
        [HttpPost]
        public JsonResult Create([FromBody]BonusTopic obj)
        {
            return Json(_BonusTopic.Create(obj));
        }
        
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]BonusTopic obj)
        {
            return Json(_BonusTopic.Update(_id, obj));
        }

        //Delete
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_BonusTopic.Delete(_id));
        }
    }
}