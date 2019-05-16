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
    public interface ISystem_UserRoleService
    {
        IQueryable<System_UserRole> GetAll();
        System_UserRole GetById(string Id);
        MessageReport Create(System_UserRole obj);
        MessageReport Delete(string _id);
    }
    public class System_UserRoleService : ISystem_UserRoleService
    {
        private readonly ISystem_UserRoleRepository _System_UserRoleRepository;
        public System_UserRoleService(ISystem_UserRoleRepository _System_UserRoleRepository)
        {
            this._System_UserRoleRepository = _System_UserRoleRepository;
        }

        public MessageReport Create(System_UserRole obj)
        {
            var rp = new MessageReport();
            try
            {
                _System_UserRoleRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm nhóm quyền cho người dùng thành công!";
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
                var query = Builders<System_UserRole>.Filter.Eq(x => x._id, _id);
                _System_UserRoleRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa người dùng khỏi nhóm quyền thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<System_UserRole> GetAll()
        {
            var query = from n in _System_UserRoleRepository.Table
                        select n;
            return query;
        }

        public System_UserRole GetById(string Id)
        {
            var query = from n in _System_UserRoleRepository.Table
                        where n._id.Equals(Id)
                        select n;
            return query.FirstOrDefault();
        }
    }
}
