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
    public interface IEventService
    {
        PagedListModel<Event> GetByPaged(string Account_id, string Key, int PageNumber, int PageSize);

        Event GetById(string Id);
        IQueryable<Event> GetAll();
        MessageReport Create(Event obj);
        MessageReport Update(string _id, Event obj);
        MessageReport Delete(string _id);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository _IEventRepository;
        private readonly IAccountRepository _IAccountRepository;

        public EventService(IEventRepository _IEventRepository, IAccountRepository _IAccountRepository)
        {
            this._IEventRepository = _IEventRepository;
            this._IAccountRepository = _IAccountRepository;
        }

        public MessageReport Create(Event obj)
        {
            var rp = new MessageReport();
            try
            {
                _IEventRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm Event thành công!";
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
                var query = Builders<Event>.Filter.Eq(x => x._id, _id);
                _IEventRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa thành công!";
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Event> GetAll()
        {
            var query = from n in _IEventRepository.Table
                        join m in _IAccountRepository.Table on n.Account_id equals m._id
                        select new Event()
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            Bonus = n.Bonus,
                            ContentEvent = n.ContentEvent,
                            Result = n.Result,
                            TimeEnd = n.TimeEnd,
                            TimeStart = n.TimeStart
                        };
            return query;
        }

        public Event GetById(string Id)
        {
            var filter = Builders<Event>.Filter.Eq(x => x._id, Id);
            var data = _IEventRepository.GetById(filter);
            return data;
        }

        public PagedListModel<Event> GetByPaged(string Account_id, string Key, int PageNumber, int PageSize)
        {
            var query = from n in _IEventRepository.Table
                        join m in _IAccountRepository.Table on n.Account_id equals m._id
                        select new Event()
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            Bonus = n.Bonus,
                            ContentEvent = n.ContentEvent,
                            Result = n.Result,
                            TimeEnd = n.TimeEnd,
                            TimeStart = n.TimeStart
                        };
            if(!string.IsNullOrWhiteSpace(Account_id))
            {
                query = query.Where(x => x.Account_id.Equals(Account_id));
            }
            if(!string.IsNullOrWhiteSpace(Key))
            {
                query = query.Where(x => x.ContentEvent.Equals(Key));
            }
            var data = new PagedList<Event>(query.OrderBy(x => x.TimeStart), PageNumber, PageSize);
            var pagedList = PageModelCustom<Event>.GetPage(data, PageNumber, PageSize);
            return pagedList;

        }

        public MessageReport Update(string _id, Event obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Event>.Filter.Eq(x => x._id, _id);
                var update = Builders<Event>.Update.Set(x => x.TimeStart, obj.TimeStart)
                    .Set(x => x.TimeEnd, obj.TimeEnd)
                    .Set(x => x.Result, obj.Result)
                    .Set(x => x.ContentEvent, obj.ContentEvent)
                    .Set(x => x.Bonus, obj.Bonus)
                    .Set(x => x.Account_id, obj.Account_id);
                _IEventRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật thành công!";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
