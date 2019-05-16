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
    public interface ISystem_RolesService
    {
        IQueryable<System_Roles> GetAll();
        System_Roles GetById(string Id);
        MessageReport Create(System_Roles obj);
        MessageReport Update(string _id, System_Roles obj);
        MessageReport Delete(string _id);
    }
    public class System_RolesService : ISystem_RolesService
    {
        private readonly ISystem_RolesRepository _System_RolesRepository;
        public System_RolesService(ISystem_RolesRepository _System_RolesRepository)
        {
            this._System_RolesRepository = _System_RolesRepository;
        }

        public MessageReport Create(System_Roles obj)
        {
            var rp = new MessageReport();
            try
            {
                _System_RolesRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm nhóm quyền thành công!";
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
                var query = Builders<System_Roles>.Filter.Eq(x => x._id, _id);
                _System_RolesRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa nhóm quyền thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<System_Roles> GetAll()
        {
            var query = from n in _System_RolesRepository.Table
                        select n;
            return query;
        }

        public System_Roles GetById(string Id)
        {
            var query = from n in _System_RolesRepository.Table
                        where n._id.Equals(Id)
                        select n;
            return query.FirstOrDefault();
        }

        public MessageReport Update(string _id, System_Roles obj)
        {
            var report = new MessageReport();
            try
            {
                var query = Builders<System_Roles>.Filter.Eq(e => e._id, _id);
                var update = Builders<System_Roles>.Update
                    .Set(x => x.Name, obj.Name)
                    .Set(x => x.Description, obj.Description)
                    .Set(x => x.IsActive, obj.IsActive);
                _System_RolesRepository.Update(query, update);
                report.Success = true;
                report.Message = "Cập nhật nhóm quyền thành công!";

            }
            catch (Exception ex)
            {
                report.Message = ex.Message;
            }
            return report;
        }
    }
}
