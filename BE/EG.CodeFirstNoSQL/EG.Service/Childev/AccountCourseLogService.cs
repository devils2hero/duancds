using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using EG.Web.Core.Helpers;
using MongoDB.Driver;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EG.Service.Childev
{
    public interface IAccountCourseLogService
    {
      
        IQueryable<AccountCourseLog> GetAll();

        AccountCourseLog GetById(string id);
        MessageReport Create(AccountCourseLog obj);
        MessageReport Update(string _id, AccountCourseLog obj);
        MessageReport Delete(string _id);
    }
    public class AccountCourseLogService : IAccountCourseLogService
    {
        private readonly IAccountRepository _IAccountRepository;
        private readonly ICourseRepository _ICourseRepository;
        private readonly IAccountCourseLogRepository _IAccountCourseLogRepository;

        public AccountCourseLogService(IAccountCourseLogRepository _IAccountCourseLogRepository, IAccountRepository _IAccountRepository, ICourseRepository _ICourseRepository)
        {
            this._IAccountCourseLogRepository = _IAccountCourseLogRepository;
            this._ICourseRepository = _ICourseRepository;
            this._IAccountRepository = _IAccountRepository;
        }
        public MessageReport Create(AccountCourseLog obj)
        {
            var rp = new MessageReport();
            try
            {
                _IAccountCourseLogRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm thành công!";
            }catch(Exception ex)
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
                var query = Builders<AccountCourseLog>.Filter.Eq(x => x._id, _id);
                _IAccountCourseLogRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công!";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<AccountCourseLog> GetAll()
        {
            var query = from n in _IAccountCourseLogRepository.Table
                        join m in _IAccountRepository.Table on n.Account_id equals m._id
                        join k in _ICourseRepository.Table on n.Course_id equals k._id
                        select new AccountCourseLog
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            Course_id = n.Course_id,
                            CreatedDate = n.CreatedDate,
                            IsActive = n.IsActive,
                            Price = n.Price
                        };
            return query;
        }

        public AccountCourseLog GetById(string id)
        {
            var filter = Builders<AccountCourseLog>.Filter.Eq(x => x._id, id);
            var data = _IAccountCourseLogRepository.GetById(filter);
            return data;
        }

        public MessageReport Update(string _id, AccountCourseLog obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<AccountCourseLog>.Filter.Eq(x => x._id, _id);
                var update = Builders<AccountCourseLog>.Update.Set(x => x.Course_id, obj.Course_id)
                    .Set(x => x.Account_id, obj.Account_id)
                    .Set(x => x.CreatedDate, obj.CreatedDate)
                    .Set(x => x.IsActive, obj.IsActive)
                    .Set(x => x.Price, obj.Price);
                _IAccountCourseLogRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật thành công";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
