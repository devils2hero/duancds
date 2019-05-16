using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.Models.Childev;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EG.Service.Childev
{
    public interface IConquestTopics
    {
        IQueryable<ConquestTopic> GetAll();
        ConquestTopic GetById(string id);
        MessageReport Create(ConquestTopic obj);
        MessageReport Update(string _id, ConquestTopic obj);
        MessageReport Delete(string _id);
    }
    public class ConquestTopicsService : IConquestTopics
    {
        private readonly IConquestTopicsRepository _IConquestTopicsRepository;
        private readonly ITopicRepository _ITopicRepository;
        private readonly IAccountRepository _IAccountRepository;


        public ConquestTopicsService(IConquestTopicsRepository _IConquestTopicsRepository, ITopicRepository _ITopicRepository, IAccountRepository _IAccountRepository)
        {
            this._IAccountRepository = _IAccountRepository;
            this._IConquestTopicsRepository = _IConquestTopicsRepository;
            this._ITopicRepository = _ITopicRepository;
        }
        public MessageReport Create(ConquestTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                _IConquestTopicsRepository.Add(obj);
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
                var query = Builders<ConquestTopic>.Filter.Eq(x => x._id, _id);
                _IConquestTopicsRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công!";
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<ConquestTopic> GetAll()
        {
            var query = from n in _IConquestTopicsRepository.Table
                        join m in _ITopicRepository.Table on n.Topics_id equals m._id
                        join k in _IAccountRepository.Table on n.Account_id equals k._id
                        select new ConquestTopic()
                        {
                            _id = n._id,
                            Account_id = n.Account_id,
                            Topics_id = n.Topics_id,
                            CompleteDate = n.CompleteDate,
                            CreatedDate = n.CreatedDate,
                            IsComplete = n.IsComplete,
                            Note = n.Note
                        };
            return query;
        }

        public ConquestTopic GetById(string id)
        {
            var filter = Builders<ConquestTopic>.Filter.Eq(x => x._id, id);
            var data = _IConquestTopicsRepository.GetById(filter);
            return data;
        }

        public MessageReport Update(string _id, ConquestTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<ConquestTopic>.Filter.Eq(x => x._id, _id);
                var update = Builders<ConquestTopic>.Update
                    .Set(x => x.Topics_id, obj.Topics_id)
                    .Set(x => x.Note, obj.Note)
                    .Set(x => x.IsComplete, obj.IsComplete)
                    .Set(x => x.CreatedDate, obj.CreatedDate)
                    .Set(x => x.Account_id, obj.Account_id)
                    .Set(x => x.CompleteDate, obj.CompleteDate);
                _IConquestTopicsRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật thành công!";

                    }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
