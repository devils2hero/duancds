using EG.Model.Models.Childev;
using EG.Service.Childev;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EG.API.Controllers.Childev
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("AuthAPIChildDevelopSkills")]
    public class HomeController : Controller
    {
        private readonly IHomeService _HomeService;
        public HomeController(IHomeService _HomeService)
        {
            this._HomeService = _HomeService;
        }

        // POST: api/Home
        [HttpPost]
        public JsonResult Post([FromBody]Home obj)
        {
            return Json(_HomeService.Create(obj));
        }

        // PUT: api/Home/5
        [HttpPut("{_id}")]
        public JsonResult Put(string _id, [FromBody]Home obj)
        {
            return Json(_HomeService.Update(_id, obj));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_HomeService.Delete(_id));
        }
    }
}
