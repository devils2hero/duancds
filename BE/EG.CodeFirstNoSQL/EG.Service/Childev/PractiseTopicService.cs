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
    public interface IPractiseTopic
    {
        PagedListModel<PractiseTopic> GetByPaged(string Topic_id, string Account_id, string key, int PageNumber, int PageSize);
        IQueryable<PractiseTopic> GetAll();
        PractiseTopic GetById(string id);
        MessageReport Create(PractiseTopic obj);
        MessageReport Update(string _id, PractiseTopic obj);
        MessageReport Delete(string _id);
    }
    public class PractiseTopicService : IPractiseTopic
    {
        private readonly IAccountRepository _IAccountRepository;
        private readonly ITopicRepository _ITopicRepository;
        private readonly IPratiseTopicRepository _IPratiseTopicRepository;

        public PractiseTopicService(IPratiseTopicRepository _IPratiseTopicRepository, ITopicRepository _ITopicRepository, IAccountRepository _IAccountRepository)
        {
            this._IPratiseTopicRepository = _IPratiseTopicRepository;
            this._IAccountRepository = _IAccountRepository;
            this._ITopicRepository = _ITopicRepository;
        }
        public MessageReport Create(PractiseTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                _IPratiseTopicRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm chủ đề thực hành thành công!";
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
                var query = Builders<PractiseTopic>.Filter.Eq(x => x._id, _id);
                _IPratiseTopicRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa thành công!";
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<PractiseTopic> GetAll()
        {
            var query = from n in _IPratiseTopicRepository.Table
                        join m in _ITopicRepository.Table on n.Topic_id equals m._id
                        join k in _IAccountRepository.Table on n.Account_id equals k._id
                        select new PractiseTopic()
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            ComleteDate = n.ComleteDate,
                            CreatedDate = n.CreatedDate,
                            IsComplete = n.IsComplete,
                            Note = n.Note,
                            Topic_id = n.Topic_id
                       };
            return query;
        }

        public PractiseTopic GetById(string id)
        {
            var filter = Builders<PractiseTopic>.Filter.Eq(x => x._id, id);
            var data = _IPratiseTopicRepository.GetById(filter);
            return data;
        }

        public PagedListModel<PractiseTopic> GetByPaged(string Topic_id, string Account_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _IPratiseTopicRepository.Table
                        join m in _ITopicRepository.Table on n.Topic_id equals m._id
                        join k in _IAccountRepository.Table on n.Account_id equals k._id
                        select new PractiseTopic()
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            ComleteDate = n.ComleteDate,
                            CreatedDate = n.CreatedDate,
                            IsComplete = n.IsComplete,
                            Note = n.Note,
                            Topic_id = n.Topic_id
                        };
            if(!string.IsNullOrWhiteSpace(Topic_id) && !string.IsNullOrWhiteSpace(Account_id))
            {
                query = query.Where(x => x.Account_id.Equals(Account_id) && x.Topic_id.Equals(Topic_id));
            }
            if(!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(x => x.CreatedDate.Equals(key));
            }
            var data = new PagedList<PractiseTopic>(query.OrderBy(x => x.CreatedDate), PageNumber, PageSize);
            var pagedList = PageModelCustom<PractiseTopic>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, PractiseTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<PractiseTopic>.Filter.Eq(x => x._id,_id);
                var update = Builders<PractiseTopic>.Update.Set(x => x.Topic_id, obj.Topic_id)
                    .Set(x => x.Account_id, obj.Account_id).Set(x => x.ComleteDate, obj.ComleteDate)
                    .Set(x => x.CreatedDate, obj.CreatedDate)
                    .Set(x => x.Note, obj.Note).Set(x => x.IsComplete, obj.IsComplete)
                    .Set(x => x.ComleteDate, obj.ComleteDate);
                _IPratiseTopicRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhập thành công!";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
