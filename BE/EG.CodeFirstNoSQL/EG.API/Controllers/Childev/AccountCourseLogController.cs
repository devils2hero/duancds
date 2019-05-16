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
    public class AccountCourseLogController : Controller
    {
        private readonly IAccountCourseLogService _AccountCourseLogService;
        public AccountCourseLogController(IAccountCourseLogService _AccountCourseLogService)
        {
            this._AccountCourseLogService = _AccountCourseLogService;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_AccountCourseLogService.GetAll());
        }

        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_AccountCourseLogService.GetById(_id));
        }

        [HttpPost]
        public JsonResult Create([FromBody]AccountCourseLog obj)
        {
            return Json(_AccountCourseLogService.Create(obj));
        }

        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]AccountCourseLog obj)
        {
            return Json(_AccountCourseLogService.Update(_id, obj));
        }

    }
}