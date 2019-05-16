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
    public interface IAnswerService
    {
        PagedListModel<Answer> GetByPaged(string Question_id, string key, int PageNumber, int PageSize);
        IQueryable<Answer> GetAll();

        Answer GetById(string id); 
        MessageReport Create(Answer obj);
        MessageReport Update(string _id, Answer obj);
        MessageReport Delete(string _id);


    }
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _IAnswerRepository;
        private readonly IQuestionRepository _IQuestionRepository;

        public AnswerService(IAnswerRepository _IAnswerRepository, IQuestionRepository _IQuestionRepository)
        {
            this._IAnswerRepository = _IAnswerRepository;
            this._IQuestionRepository = _IQuestionRepository;
        }
        public MessageReport Create(Answer obj)
        {
            var rp = new MessageReport();
            try
            {
                _IAnswerRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Thêm câu trả lời thành công!";

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

                var query = Builders<Answer>.Filter.Eq(x => x._id, _id);
                _IAnswerRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công câu trả lời!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Answer> GetAll()
        {

            var query = from n in _IAnswerRepository.Table
                        join m in _IQuestionRepository.Table on n.Quesiton_id equals m._id
                        select new Answer()
                        {
                            _id = n._id,
                            Quesiton_id = n.Quesiton_id,
                            AudioPath = n.AudioPath,
                            Content = n.Content,
                            CorrectIndex = n.CorrectIndex,
                            CreatedDate = n.CreatedDate,
                            ImagePath = n.ImagePath,
                            IsActive = n.IsActive
                        };
            return query;
        }

        public Answer GetById(string id)
        {
            var filter = Builders<Answer>.Filter.Eq(x => x._id, id);
            var data = _IAnswerRepository.GetById(filter);
            return data;
        }

        public PagedListModel<Answer> GetByPaged(string Question_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _IAnswerRepository.Table
                        join m in _IQuestionRepository.Table on n.Quesiton_id equals m._id
                        select new Answer()
                        {
                            _id = n._id,
                            AudioPath = n.AudioPath,
                            Content = n.Content,
                            CorrectIndex = n.CorrectIndex,
                            CreatedDate = n.CreatedDate,
                            ImagePath = n.ImagePath,
                            IsActive = n.IsActive,
                            Quesiton_id = n.Quesiton_id
                        };
            if (!string.IsNullOrWhiteSpace(Question_id))
            {
                query = query.Where(x => x.Quesiton_id.Equals(Question_id));
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(x => x.CorrectIndex.Equals(key));
            }
            var data = new PagedList<Answer>(query.OrderBy(x => x.Quesiton_id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Answer>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, Answer obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Answer>.Filter.Eq(x => x._id, _id);
                var update = Builders<Answer>.Update.Set(x => x.Quesiton_id, obj.Quesiton_id)
                    .Set(x => x.AudioPath, obj.AudioPath)
                    .Set(x => x.Content, obj.Content)
                    .Set(x => x.CorrectIndex, obj.CorrectIndex)
                    .Set(x => x.CreatedDate, obj.CreatedDate)
                    .Set(x => x.ImagePath, obj.ImagePath)
                    .Set(x => x.IsActive, obj.IsActive);
                _IAnswerRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật đáp án thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

    }
}
