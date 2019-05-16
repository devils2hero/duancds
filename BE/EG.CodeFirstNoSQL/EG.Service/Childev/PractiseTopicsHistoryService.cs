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
    public interface IPractiseTopicsHistory
    {
        IQueryable<PractiseTopicsHistory> GetAll();
        PractiseTopicsHistory GetById(string id);
        MessageReport Create(PractiseTopicsHistory obj);
        MessageReport Update(string _id, PractiseTopicsHistory obj);
        MessageReport Delete(string _id);
    }
    public class PractiseTopicsHistoryService : IPractiseTopicsHistory
    {
        private readonly IPractiseTopicsHistoryRepository _IPractiseTopicsHistoryRepository;
        private readonly IPratiseTopicRepository _IPratiseTopicRepository;
        private readonly IQuestionRepository _IQuestionRepository;

        public PractiseTopicsHistoryService(IPractiseTopicsHistoryRepository _IPractiseTopicsHistoryRepository, IPratiseTopicRepository _IPratiseTopicRepository, IQuestionRepository _IQuestionRepository)
        {
            this._IPractiseTopicsHistoryRepository = _IPractiseTopicsHistoryRepository;
            this._IPratiseTopicRepository = _IPratiseTopicRepository;
            this._IQuestionRepository = _IQuestionRepository;
        }
        public MessageReport Create(PractiseTopicsHistory obj)
        {
            var rp = new MessageReport();
            try
            {
                _IPractiseTopicsHistoryRepository.Add(obj);
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
                var query = Builders<PractiseTopicsHistory>.Filter.Eq(x => x._id, _id);
                _IPractiseTopicsHistoryRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa thành công!";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }

            return rp;
        }

        public IQueryable<PractiseTopicsHistory> GetAll()
        {
            var query = from n in _IPractiseTopicsHistoryRepository.Table
                        join m in _IPratiseTopicRepository.Table on n.PractiseTopics_id equals m._id
                        join k in _IQuestionRepository.Table on n.Question_id equals k._id
                        select new PractiseTopicsHistory()
                        {
                            _id = n._id,
                            Question_id = n.Question_id,
                            PractiseTopics_id = n.PractiseTopics_id
                        };
            return query;
        }

        public PractiseTopicsHistory GetById(string id)
        {
            var filter = Builders<PractiseTopicsHistory>.Filter.Eq(x => x._id, id);
            var query = _IPractiseTopicsHistoryRepository.GetById(filter);
            return query;
        }

        public MessageReport Update(string _id, PractiseTopicsHistory obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<PractiseTopicsHistory>.Filter.Eq(x => x._id, obj._id);
                var update = Builders<PractiseTopicsHistory>.Update.Set(x => x.Question_id, obj.Question_id)
                    .Set(x => x.PractiseTopics_id, obj.PractiseTopics_id);
                _IPractiseTopicsHistoryRepository.Update(query, update);
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
