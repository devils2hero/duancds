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
    public class PractiseTopicsHistoryController : Controller
    {
        private readonly IPractiseTopicsHistory _PractiseTopicsHistory;
        public PractiseTopicsHistoryController(IPractiseTopicsHistory _PractiseTopicsHistory)
        {
            this._PractiseTopicsHistory = _PractiseTopicsHistory;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_PractiseTopicsHistory.GetAll());
        }

        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_PractiseTopicsHistory.GetById(_id));
        }

        [HttpPost]
        public JsonResult Create([FromBody]PractiseTopicsHistory obj)
        {
            return Json(_PractiseTopicsHistory.Create(obj));
        }

        [HttpPut]
        public JsonResult Update(string _id, [FromBody]PractiseTopicsHistory obj)
        {
            return Json(_PractiseTopicsHistory.Update(_id, obj));
        }

        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_PractiseTopicsHistory.Delete(_id));
        }
    }
}