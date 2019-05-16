using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using EG.Web.Core.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PagedList.Core;
using System;
using System.Linq;

namespace EG.Service.Childev
{
    public interface IHomeService
    {
        PagedListModel<Home> GetByPaged(string key, int PageNumber, int PageSize);
        Home GetById(string Id);
        MessageReport Create(Home obj);
        MessageReport Update(string _id, Home obj);
        MessageReport Delete(string _id);
    }
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _HomeRepository;
        public HomeService(IHomeRepository _HomeRepository)
        {
            this._HomeRepository = _HomeRepository;
        }

        public MessageReport Create(Home obj)
        {
            var rp = new MessageReport();
            try
            {
                _HomeRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Create Home Successfully";
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
                var query = Builders<Home>.Filter.Eq(e => e._id, _id);
                _HomeRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Delete Home Successfully";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public PagedListModel<Home> GetByPaged(string key, int PageNumber, int PageSize)
        {
            var query = from n in _HomeRepository.Table
                        select n;
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(n => n.Name.Contains(key));
            }
            var data = new PagedList<Home>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Home>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public Home GetById(string Id)
        {
            var filter = Builders<Home>.Filter.Eq(x => x._id, Id);
            var data = _HomeRepository.GetById(filter);
            return data;
        }

        public MessageReport Update(string _id, Home obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Home>.Filter.Eq(e => e._id, _id);
                var update = Builders<Home>.Update.Set(x => x.Name, obj.Name);
                _HomeRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Update Home Successfully";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
