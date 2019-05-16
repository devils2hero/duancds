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
    public interface IConquestTopicsHistory {
        IQueryable<ConquestTopicsHistory> GetAll();
        ConquestTopicsHistory GetById(string id);
        MessageReport Create(ConquestTopicsHistory obj);
        MessageReport Update(string _id, ConquestTopicsHistory obj);
        MessageReport Delete(string _id);
    }
    public class ConquestTopicsHistoryService : IConquestTopicsHistory
    {
        private readonly IConquestTopicsHistoryRepository _IConquestTopicsHistoryRepository;
        private readonly IQuestionRepository _IQuestionRepository;
        private readonly IConquestTopicsRepository _IConquestTopicsRepository;

        public ConquestTopicsHistoryService(IConquestTopicsHistoryRepository _IConquestTopicsHistoryRepository, IQuestionRepository _IQuestionRepository, IConquestTopicsRepository _IConquestTopicsRepository)
        {
            this._IConquestTopicsHistoryRepository = _IConquestTopicsHistoryRepository;
            this._IConquestTopicsRepository = _IConquestTopicsRepository;
            this._IQuestionRepository = _IQuestionRepository;
        }
        public MessageReport Create(ConquestTopicsHistory obj)
        {
            var rp = new MessageReport();
            try
            {
                _IConquestTopicsHistoryRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Tạo thành công!";
            }
           catch(Exception ex)
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
                var query = Builders<ConquestTopicsHistory>.Filter.Eq(x => x._id, _id);
                _IConquestTopicsHistoryRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công!";
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<ConquestTopicsHistory> GetAll()
        {
            var query = from n in _IConquestTopicsHistoryRepository.Table
                        join m in _IConquestTopicsRepository.Table on n.ConquestTopics_id equals m._id
                        join k in _IQuestionRepository.Table on n.Question_id equals k._id
                        select new ConquestTopicsHistory()
                        {
                            _id = n._id,
                            Question_id = n.Question_id,
                            ConquestTopics_id = n.ConquestTopics_id
                        };
            return query;
        }

        public ConquestTopicsHistory GetById(string id)
        {
            var filter = Builders<ConquestTopicsHistory>.Filter.Eq(x => x._id, id);
            var data = _IConquestTopicsHistoryRepository.GetById(filter);
            return data;
        }

        public MessageReport Update(string _id, ConquestTopicsHistory obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<ConquestTopicsHistory>.Filter.Eq(x => x._id, _id);
                var update = Builders<ConquestTopicsHistory>.Update.Set(x => x.Question_id, obj.Question_id)
                    .Set(x => x.ConquestTopics_id, obj.ConquestTopics_id);
                _IConquestTopicsHistoryRepository.Update(query, update);
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
