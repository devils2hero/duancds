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
    public interface ISystem_RoleAPIService
    {
        IQueryable<System_RoleAPI> GetAll();
        System_RoleAPI GetById(string Id);
        MessageReport Create(System_RoleAPI obj);
        MessageReport Delete(string _id);
    }
    public class System_RoleAPIService : ISystem_RoleAPIService
    {
        private readonly ISystem_RoleAPIRepository _System_RoleAPIRepository;
        public System_RoleAPIService(ISystem_RoleAPIRepository _System_RoleAPIRepository)
        {
            this._System_RoleAPIRepository = _System_RoleAPIRepository;
        }

        public MessageReport Create(System_RoleAPI obj)
        {
            var rp = new MessageReport();
            try
            {
                _System_RoleAPIRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm API vào nhóm quyền thành công!";
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
                var query = Builders<System_RoleAPI>.Filter.Eq(x => x._id, _id);
                _System_RoleAPIRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa API khỏi nhóm quyền thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<System_RoleAPI> GetAll()
        {
            var query = from n in _System_RoleAPIRepository.Table
                        select n;
            return query;
        }

        public System_RoleAPI GetById(string Id)
        {
            var query = from n in _System_RoleAPIRepository.Table
                        where n._id.Equals(Id)
                        select n;
            return query.FirstOrDefault();
        }
    }
}
