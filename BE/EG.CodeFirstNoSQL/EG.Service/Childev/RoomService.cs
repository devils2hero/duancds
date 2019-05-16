using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.CustomModels.API;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using EG.Web.Core.Helpers;
using MongoDB.Driver;
using PagedList.Core;
using System;
using System.Linq;

namespace EG.Service.Childev
{
    public interface IRoomService
    {
        PagedListModel<RoomCustom> GetByPaged(string Home_id, string key, int PageNumber, int PageSize);
        IQueryable<RoomCustom> GetAll(string Home_id);
        Room GetById(string Id);
        MessageReport Create(Room obj);
        MessageReport Update(string _id, Room obj);
        MessageReport Delete(string _id);
    }
    public class RoomService : IRoomService
    {
        private readonly IHomeRepository _HomeRepository;
        private readonly IRoomRepository _RoomRepository;
        public RoomService(IRoomRepository _RoomRepository, IHomeRepository _HomeRepository)
        {
            this._RoomRepository = _RoomRepository;
            this._HomeRepository = _HomeRepository;
        }

        public MessageReport Create(Room obj)
        {
            var rp = new MessageReport();
            try
            {
                _RoomRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Create Room Successfully";
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
                var query = Builders<Room>.Filter.Eq(e => e._id, _id);
                _RoomRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Delete Room Successfully";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<RoomCustom> GetAll(string Home_id)
        {
            var query = from n in _RoomRepository.Table
                        join m in _HomeRepository.Table on n.Home_id equals m._id
                        where n.Home_id.Equals(Home_id)
                        select new RoomCustom()
                        {
                            _id = n._id,
                            Home_id = n.Home_id,
                            Home_name = m.Name,
                            Name = n.Name,
                            Acreage = n.Acreage,
                            IsUsed = n.IsUsed
                        };
            return query;
        }

        public Room GetById(string Id)
        {
            var filter = Builders<Room>.Filter.Eq(x => x._id, Id);
            var data = _RoomRepository.GetById(filter);
            return data;
        }

        public PagedListModel<RoomCustom> GetByPaged(string Home_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _RoomRepository.Table
                        join m in _HomeRepository.Table on n.Home_id equals m._id
                        select new RoomCustom()
                        {
                            _id = n._id,
                            Home_id = n.Home_id,
                            Home_name = m.Name,
                            Name = n.Name,
                            Acreage = n.Acreage,
                            IsUsed = n.IsUsed
                        };
            if (!string.IsNullOrWhiteSpace(Home_id))
            {
                query = query.Where(n => n.Home_id.Equals(Home_id));
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(n => n.Name.Contains(key));
            }
            var data = new PagedList<RoomCustom>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<RoomCustom>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, Room obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Room>.Filter.Eq(e => e._id, _id);
                var update = Builders<Room>.Update.Set(x => x.Name, obj.Name).Set(x => x.Acreage, obj.Acreage).Set(x => x.IsUsed, obj.IsUsed);
                _RoomRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Update Room Successfully";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
