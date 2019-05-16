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
    public class RoomController : Controller
    {
        private readonly IRoomService _RoomService;
        public RoomController(IRoomService _RoomService)
        {
            this._RoomService = _RoomService;
        }
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Room obj)
        {
            return Json(_RoomService.Create(obj));
        }

        // PUT api/values/5
        [HttpPut("{_id}")]
        public JsonResult Put(string _id, [FromBody] Room obj)
        {
            return Json(_RoomService.Update(_id, obj));
        }

        // DELETE api/values/5
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_RoomService.Delete(_id));
        }
    }
}