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
    public interface ISystem_APIService
    {
        IQueryable<System_API> GetAll();
        System_API GetById(string Id);
        MessageReport Create(System_API obj);
        MessageReport Update(string _id, System_API obj);
        MessageReport Delete(string _id);
    }
    public class System_APIService : ISystem_APIService
    {
        private readonly ISystem_APIRepository _System_APIRepository;
        public System_APIService(ISystem_APIRepository _System_APIRepository)
        {
            this._System_APIRepository = _System_APIRepository;
        }

        public MessageReport Create(System_API obj)
        {
            var rp = new MessageReport();
            try
            {
                _System_APIRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm API thành công!";
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
                var query = Builders<System_API>.Filter.Eq(x => x._id, _id);
                _System_APIRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa API thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<System_API> GetAll()
        {
            var query = from n in _System_APIRepository.Table
                        select n;
            return query;
        }

        public System_API GetById(string Id)
        {
            var query = from n in _System_APIRepository.Table
                        where n._id.Equals(Id)
                        select n;
            return query.FirstOrDefault();
        }

        public MessageReport Update(string _id, System_API obj)
        {
            var report = new MessageReport();
            try
            {
                var query = Builders<System_API>.Filter.Eq(e => e._id, _id);
                var update = Builders<System_API>.Update
                    .Set(x => x.Name, obj.Name)
                    .Set(x => x.Controller, obj.Controller)
                    .Set(x => x.Action, obj.Action)
                    .Set(x => x.ParamsName, obj.ParamsName)
                    .Set(x => x.MethodType, obj.MethodType)
                    .Set(x => x.IsActive, obj.IsActive);
               _System_APIRepository.Update(query, update);
                report.Success = true;
                report.Message = "Cập nhật API thành công!";

            }
            catch (Exception ex)
            {
                report.Message = ex.Message;
            }
            return report;
        }
    }
}
