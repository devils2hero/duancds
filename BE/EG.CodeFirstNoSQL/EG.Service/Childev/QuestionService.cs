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
    public interface IQuestionService
    {
        PagedListModel<Question> GetByPaged(string Topic_id, string key, int PageNumber, int PageSize);
        IQueryable<Question> GetAll();

        Question GetById(string Id);
        MessageReport Create(Question question);
        MessageReport Update(string _id, Question obj);
        MessageReport Delete(string _id);
    }
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _IQuestionRepository;
        private readonly ITopicRepository _ITopicRepository;

        public QuestionService(IQuestionRepository _IQuestionRepository, ITopicRepository _ITopicRepository)
        {
            this._IQuestionRepository = _IQuestionRepository;
            this._ITopicRepository = _ITopicRepository;
        }
        public MessageReport Create(Question question)
        {
            var rp = new MessageReport();
            try
            {
                _IQuestionRepository.Add(question);
                rp.Success = true;
                rp.Message = "Thêm câu hỏi thành công!";
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
                var query = Builders<Question>.Filter.ElemMatch(e => e._id, _id);
                _IQuestionRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa câu hỏi thành công!";
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Question> GetAll()
        {
            var query = from n in _IQuestionRepository.Table
                        join m in _ITopicRepository.Table on n.Topic_id equals m._id
                        select new Question()
                        {
                            _id = n._id,
                            Topic_id = n.Topic_id,
                            AudioPath = n.AudioPath,
                            Content = n.Content,
                            CreatedDate = n.CreatedDate,
                            ImagePath = n.ImagePath,
                            IsActive = n.IsActive,
                            Title = n.Title
                        };
            return query;
        }

        public Question GetById(string Id)
        {
            var query = Builders<Question>.Filter.Eq(x => x._id, Id);
            var data = _IQuestionRepository.GetById(query);
            return data;
        }

        public PagedListModel<Question> GetByPaged(string Topic_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _IQuestionRepository.Table
                        join m in _ITopicRepository.Table on n.Topic_id equals m._id
                        select new Question()
                        {
                            _id = n._id,
                            Topic_id = n.Topic_id,
                            AudioPath = n.AudioPath,
                            Content = n.Content,
                            CreatedDate = n.CreatedDate,
                            ImagePath = n.ImagePath,
                            IsActive = n.IsActive,
                            Title = n.Title
                        };
            if(!string.IsNullOrWhiteSpace(Topic_id))
            {
                query = query.Where(x => x.Topic_id.Equals(Topic_id));
            }
            if(!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(x => x.Title.Contains(key));
            }
            var data = new PagedList<Question>(query.OrderBy(x => x.Title), PageNumber, PageSize);
            var pagedList = PageModelCustom<Question>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, Question obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Question>.Filter.Eq(x => x._id,_id);
                var update = Builders<Question>.Update.Set(x => x.Topic_id, obj.Topic_id)
                    .Set(x => x.AudioPath, obj.AudioPath)
                    .Set(x => x.Content, obj.Content)
                    .Set(x => x.CreatedDate, obj.CreatedDate)
                    .Set(x => x.ImagePath, obj.ImagePath)
                    .Set(x => x.IsActive, obj.IsActive)
                    .Set(x => x.Title, obj.Title);
                _IQuestionRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật câu hỏi thành công!";
            
            }catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
