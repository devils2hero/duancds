using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EG.Model.CustomModels;
using EG.Model.Models.Childev;
using EG.Service.Childev;
using EG.Web.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EG.API.Controllers.Childev
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _AccountService;
        public AccountController(IAccountService _AccountService)
        {
            this._AccountService = _AccountService; 
        }
         //GetAll
        [HttpGet] 
        public JsonResult GetAll()
        {
            return Json(_AccountService.GetAll());
        }
        //GetById
        [HttpGet("{_id}")]
        public JsonResult GetById(string _id)
        {
            return Json(_AccountService.GetById(_id));
        }
        //Create
        [HttpPost]
        public JsonResult Create([FromBody]Account obj)
        {
            var rp = new MessageReport();
            try
            {
                obj.PasswordSalt = Guid.NewGuid().ToString();
                obj.Password = obj.Password.PasswordHashed(obj.PasswordSalt);
                rp = _AccountService.Create(obj);
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return Json(rp);
        }
        //Update
        [HttpPut("{_id}")]
        public JsonResult Update(string _id,[FromBody]Account obj)
        {
            return Json(_AccountService.Update(_id, obj));
        }

        //Delete
        [HttpDelete("{_id}")]
        public JsonResult Delete(string _id)
        {
            return Json(_AccountService.Delete(_id));
        }
    }
}