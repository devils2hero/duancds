using EG.Data.Mongo.Repository.System;
using EG.Model.CustomModels;
using EG.Model.Models.System;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EG.Service.System
{
    public interface ISystem_UserService
    {
        IQueryable<System_User> GetAll();
        System_User GetById(string Id);
        MessageReport Create(System_User obj);
        MessageReport Update(string _id, System_User obj);
        MessageReport Delete(string _id);
    }
    public class System_UserService : ISystem_UserService
    {
        private readonly ISystem_UserRepository _System_UserRepository;
        public System_UserService(ISystem_UserRepository _System_UserRepository)
        {
            this._System_UserRepository = _System_UserRepository;
        }

        public MessageReport Create(System_User obj)
        {
            var rp = new MessageReport();
            try
            {
                _System_UserRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm tài khoản thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public MessageReport Delete(string _id)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<System_User>.Filter.Eq(x => x._id, _id);
                _System_UserRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa tài khoản thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<System_User> GetAll()
        {
            var query = from n in _System_UserRepository.Table
                        select n;
            return query;
        }

        public System_User GetById(string Id)
        {
            var query = from n in _System_UserRepository.Table
                        where n._id.Equals(Id)
                        select n;
            return query.FirstOrDefault();
        }

        public MessageReport Update(string _id, System_User obj)
        {
            var report = new MessageReport();
            try
            {
                var query = Builders<System_User>.Filter.Eq(e => e._id, _id);
                var update = Builders<System_User>.Update
                    .Set(x => x.Password, obj.Password)
                    .Set(x => x.Name, obj.Name)
                    .Set(x => x.UserAvatar, obj.UserAvatar)
                    .Set(x => x.Address, obj.Address)
                    .Set(x => x.Phone, obj.Phone)
                    .Set(x => x.SupperUser, obj.SupperUser)
                    .Set(x => x.IsActive, obj.IsActive);
               _System_UserRepository.Update(query, update);
                report.Success = true;
                report.Message = "Cập nhật tài khoản thành công!";

            }
            catch (Exception ex)
            {
                report.Message = ex.Message;
            }
            return report;
        }
    }
   
}
