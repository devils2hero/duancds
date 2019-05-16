using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using EG.Web.Core.Helpers;
using MongoDB.Driver;
using PagedList.Core;
using System;
using System.Linq;

namespace EG.Service.Childev
{
    public interface IAccountService
    {
        PagedListModel<Account> GetByPaged(string Key, int PageNumber, int PageSize);
        IQueryable<Account> GetAll();
        Account GetById(string _id);
        MessageReport Create(Account obj);
        MessageReport Update(string _id, Account obj);
        MessageReport Delete(string _id);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _IAccountRepository;
        public AccountService(IAccountRepository _IAccountRepository)
        {
            this._IAccountRepository = _IAccountRepository;
        }
        public MessageReport Create(Account obj)
        {
            var rp = new MessageReport();
            try
            {
                _IAccountRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Tạo tài khoản thành công!";
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
                var query = Builders<Account>.Filter.Eq(x => x._id, _id);
                _IAccountRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá tài khoản thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Account> GetAll()
        {
            var query = from n in _IAccountRepository.Table
                        select n;
            return query;
        }

        public Account GetById(string _id)
        {
            var query = Builders<Account>.Filter.Eq(x => x._id, _id);
            var data = _IAccountRepository.GetById(query);
            return data;
        }

        public PagedListModel<Account> GetByPaged(string Key, int PageNumber, int PageSize)
        {
            var query = from n in _IAccountRepository.Table
                        select n;
            if (!string.IsNullOrWhiteSpace(Key))
            {
                query = query.Where(x => x.Username.Equals(Key));
            }
            var data = new PagedList<Account>(query.OrderBy(x => x.Username), PageNumber, PageSize);
            var pagedList = PageModelCustom<Account>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, Account obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Account>.Filter.Eq(x => x._id, _id);
                var update = Builders<Account>.Update
                    .Set(x => x.Password, obj.Password)
                    .Set(x => x.Name, obj.Name)
                    .Set(x => x.Gender, obj.Gender)
                    .Set(x => x.Address, obj.Address)
                    .Set(x => x.IsActive, obj.IsActive);
                _IAccountRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật tài khoản thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
