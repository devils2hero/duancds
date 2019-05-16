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
    public interface IQuestionReport
    {
        PagedListModel<QuestionReport> GetByPaged(string Question_id, string Account_id,string Key, int PageNumber, int PageSize);
        IQueryable<QuestionReport> GetAll();

        QuestionReport GetById(string _id);
        MessageReport Create(QuestionReport obj);
        MessageReport Update(string _id, QuestionReport obj);
        MessageReport Delete(string _id);
    }
    public class QuestionReportService : IQuestionReport
    {
        private readonly IQuestionReportRepository _IQuestionReportRepository;
        private readonly IQuestionRepository _IQuesitonRepository;
        private readonly IAccountRepository _IAccountRepository;

        public QuestionReportService(IQuestionReportRepository _IQuestionReportRepository, IQuestionRepository _IQuesitonRepository, IAccountRepository _IAccountRepository)
        {
            this._IQuestionReportRepository = _IQuestionReportRepository;
            this._IQuesitonRepository = _IQuesitonRepository;
            this._IAccountRepository = _IAccountRepository;
        }
        public MessageReport Create(QuestionReport obj)
        {
            var rp = new MessageReport();
            try
            {
                _IQuestionReportRepository.Add(obj);
                rp.Success = true;
                rp.Message = "Phản hồi thành công!";
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
                var query = Builders<QuestionReport>.Filter.Eq(x => x._id, _id);
                _IQuestionReportRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa thành công Report!";
            }
            catch(Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<QuestionReport> GetAll()
        {
            var query = from n in _IQuestionReportRepository.Table
                        join m in _IQuesitonRepository.Table on n.Question_id equals m._id
                        join k in _IAccountRepository.Table on n.Account_id equals k._id
                        select new QuestionReport()
                        {
                            _id = n._id,
                            Question_id = n.Question_id,
                            Account_id = n.Account_id,
                            Content = n.Content,
                            CreatedDate = n.CreatedDate
                        };
            return query;
                        
        }

        public QuestionReport GetById(string _id)
        {
            var query = Builders<QuestionReport>.Filter.Eq(x => x._id, _id);
            var data = _IQuestionReportRepository.GetById(query);
            return data;
        }

        public PagedListModel<QuestionReport> GetByPaged(string Question_id, string Account_id,string Key, int PageNumber, int PageSize)
        {
            var query = from n in _IQuestionReportRepository.Table
                        join m in _IQuesitonRepository.Table on n.Question_id equals m._id
                        join k in _IAccountRepository.Table on n.Account_id equals k._id
                        select new QuestionReport()
                        {
                            _id = n._id,
                            Question_id = n.Question_id,
                            Account_id = n.Account_id,
                            Content = n.Content,
                            CreatedDate = n.CreatedDate
                        };
            if(!string.IsNullOrWhiteSpace(Question_id) && !string.IsNullOrWhiteSpace(Account_id))
            {
                query = query.Where(x => x.Question_id.Equals(Question_id) && x.Account_id.Equals(Account_id));
            }
            if(!string.IsNullOrWhiteSpace(Key))
            {
                query = query.Where(x => x.Content.Equals(Key));
            }
            var data = new PagedList<QuestionReport>(query.OrderBy(x => x.Question_id), PageNumber, PageSize);
            var pagedList = PageModelCustom<QuestionReport>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, QuestionReport obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<QuestionReport>.Filter.Eq(x => x._id, _id);
                var update = Builders<QuestionReport>.Update.Set(x => x.Question_id, obj.Question_id)
                    .Set(x => x.Account_id, obj.Account_id)
                    .Set(x => x.Content, obj.Content)
                    .Set(x => x.CreatedDate, obj.CreatedDate);
                _IQuestionReportRepository.Update(query, update);
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
