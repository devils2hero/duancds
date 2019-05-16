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
    public class ConquestTopicsHistoryController : Controller
    {
        private readonly IConquestTopicsHistory _IConquestTopicsHistory;
        public ConquestTopicsHistoryController(IConquestTopicsHistory _IConquestTopicsHistory)
        {
            this._IConquestTopicsHistory = _IConquestTopicsHistory;
        }
        
        //GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_IConquestTopicsHistory.GetAll());
        }
        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_IConquestTopicsHistory.GetById(_id));
        }

        //Create
        [HttpPost]
        public JsonResult Create([FromBody]ConquestTopicsHistory obj)
        {
            return Json(_IConquestTopicsHistory.Create(obj));
        }
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]ConquestTopicsHistory obj)
        {
            return Json(_IConquestTopicsHistory.Update(_id, obj));
        }
        //Delete
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_IConquestTopicsHistory.Delete(_id));
        }

    }
}