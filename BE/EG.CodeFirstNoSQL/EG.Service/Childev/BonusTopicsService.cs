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
    public interface IBonusTopics
    {
        IQueryable<BonusTopic> GetAll();
        BonusTopic GetById(string Id);
        MessageReport Create(BonusTopic obj);
        MessageReport Update(string id, BonusTopic obj);
        MessageReport Delete(string id);

    }
    public class BonusTopicsService : IBonusTopics
    {
        private readonly IBonusTopicsRepository _IBonusTopicsRepository;
        private readonly IAccountRepository _IAccountRepository;
        private readonly IQuestionRepository _IQuestionRepository;

        public BonusTopicsService(IBonusTopicsRepository _IBonusTopicsRepository, IAccountRepository _IAccountRepository, IQuestionRepository _IQuestionRepository)
        {
            this._IBonusTopicsRepository = _IBonusTopicsRepository;
            this._IQuestionRepository = _IQuestionRepository;
            this._IAccountRepository = _IAccountRepository;
        }
        public MessageReport Create(BonusTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                _IBonusTopicsRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public MessageReport Delete(string id)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<BonusTopic>.Filter.Eq(x => x._id, id);
                _IBonusTopicsRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<BonusTopic> GetAll()
        {
            var query = from n in _IBonusTopicsRepository.Table
                        join m in _IAccountRepository.Table on n.Account_id equals m._id
                        join k in _IQuestionRepository.Table on n.Question_id equals k._id
                        select new BonusTopic()
                        {
                            _id = n._id,
                            Question_id = n.Question_id,
                            Account_id = n.Account_id,
                            DateEnd = n.DateEnd,
                            DateStart = n.DateStart,
                            IsQualified = n.IsQualified,
                            Topics_id = n.Topics_id
                        };
            return query;
        }

        public BonusTopic GetById(string Id)
        {
            var query = Builders<BonusTopic>.Filter.Eq(x => x._id, Id);
            var data = _IBonusTopicsRepository.GetById(query);
            return data;
        }

        public MessageReport Update(string id, BonusTopic obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<BonusTopic>.Filter.Eq(x => x._id, id);
                var update = Builders<BonusTopic>.Update.Set(x => x.Question_id, obj.Question_id)
                    .Set(x => x.IsQualified, obj.IsQualified).Set(x => x.Topics_id, obj.Topics_id)
                    .Set(x => x.DateStart, obj.DateStart).Set(x => x.DateEnd, obj.DateEnd)
                    .Set(x => x.Account_id, obj.Account_id);
                _IBonusTopicsRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
