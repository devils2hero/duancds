using EG.Data.Mongo.Repository.Childev;
using EG.Model.CustomModels;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using EG.Web.Core.Helpers;
using MongoDB.Driver;
using PagedList.Core;
using System;
using System.Linq;

namespace EG.Service.Childev
{
    public interface ITopicService
    {
        PagedListModel<Topic> GetByPaged(string Course_id, string key, int PageNumber, int PageSize);
        PagedListModel<Topic> GetByPagedAccount(string Account_id, string Course_id, string key, int PageNumber, int PageSize);
        IQueryable<Topic> GetAll();
        Topic GetById(string Id);
        MessageReport Create(Topic topic);
        MessageReport Update(string _id, Topic obj);
        MessageReport Delete(string _id);
    }
    public class TopicService : ITopicService
    {
        private readonly ICourseRepository _ICourseRepository;
        private readonly ITopicRepository _ITopicRepository;
        private readonly IAccountCourseLogRepository _AccountCourseLogRepository;

        public TopicService(ICourseRepository _ICourseRepository, ITopicRepository _ITopicRepository, IAccountCourseLogRepository _AccountCourseLogRepository)
        {
            this._ICourseRepository = _ICourseRepository;
            this._ITopicRepository = _ITopicRepository;
            this._AccountCourseLogRepository = _AccountCourseLogRepository;
        }
        public MessageReport Create(Topic topic)
        {
            var rp = new MessageReport();
            try
            {
                _ITopicRepository.Add(topic);
                rp.Success = true;
                rp.Message = "Thêm chủ đề thành công!";
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
                var query = Builders<Topic>.Filter.Eq(e => e._id, _id);
                _ITopicRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xóa chủ đề thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Topic> GetAll()
        {
            var query = from n in _ITopicRepository.Table
                        join m in _ICourseRepository.Table on n.Course_id equals m._id
                        select new Topic()
                        {
                            _id = n._id,
                            Course_id = m._id,
                            BonusPoints = n.BonusPoints,
                            ConquestPoints = n.ConquestPoints,
                            CreatedDate = n.CreatedDate,
                            Description = n.Description,
                            ImagePath = n.ImagePath,
                            Background = n.Background,
                            IsActive = n.IsActive,
                            NumberOfPraticeDays = n.NumberOfPraticeDays,
                            PractisePoints = n.PractisePoints,
                            TopicName = n.TopicName

                        };
            return query;
        }

        public Topic GetById(string Id)
        {
            var query = Builders<Topic>.Filter.Eq(x => x._id, Id);
            var data = _ITopicRepository.GetById(query);
            return data;
        }

        public PagedListModel<Topic> GetByPaged(string Course_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _ITopicRepository.Table
                        join m in _ICourseRepository.Table on n.Course_id equals m._id
                        select new Topic()
                        {
                            _id = n._id,
                            Course_id = m._id,
                            BonusPoints = n.BonusPoints,
                            ConquestPoints = n.ConquestPoints,
                            CreatedDate = n.CreatedDate,
                            Description = n.Description,
                            ImagePath = n.ImagePath,
                            Background = n.Background,
                            IsActive = n.IsActive,
                            NumberOfPraticeDays = n.NumberOfPraticeDays,
                            PractisePoints = n.PractisePoints,
                            TopicName = n.TopicName
                        };
            if (!string.IsNullOrWhiteSpace(Course_id))
            {
                query = query.Where(n => n.Course_id.Equals(Course_id));
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(x => x.TopicName.Contains(key));
            }
            var data = new PagedList<Topic>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Topic>.GetPage(data, PageNumber, PageSize);
            return pagedList;

        }

        public PagedListModel<Topic> GetByPagedAccount(string Account_id, string Course_id, string key, int PageNumber, int PageSize)
        {
            var query = from n in _ITopicRepository.Table
                        join m in _ICourseRepository.Table on n.Course_id equals m._id
                        join acl in _AccountCourseLogRepository.Table on n._id equals acl.Course_id
                        where acl.Account_id.Equals(Account_id)
                        select new Topic()
                        {
                            _id = n._id,
                            Course_id = m._id,
                            BonusPoints = n.BonusPoints,
                            ConquestPoints = n.ConquestPoints,
                            CreatedDate = n.CreatedDate,
                            Description = n.Description,
                            ImagePath = n.ImagePath,
                            Background = n.Background,
                            IsActive = n.IsActive,
                            NumberOfPraticeDays = n.NumberOfPraticeDays,
                            PractisePoints = n.PractisePoints,
                            TopicName = n.TopicName
                        };
            if (!string.IsNullOrWhiteSpace(Course_id))
            {
                query = query.Where(n => n.Course_id.Equals(Course_id));
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(x => x.TopicName.Contains(key));
            }
            var data = new PagedList<Topic>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Topic>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public MessageReport Update(string _id, Topic obj)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Topic>.Filter.Eq(x => x._id, _id);
                var update = Builders<Topic>.Update
                    .Set(x => x.Course_id, obj.Course_id)
                    .Set(x => x.TopicName, obj.TopicName)
                    .Set(x => x.Description, obj.Description)
                    .Set(x => x.ImagePath, obj.ImagePath)
                    .Set(x => x.Background, obj.Background)
                    .Set(x => x.NumberOfPraticeDays, obj.NumberOfPraticeDays)
                    .Set(x => x.PractisePoints, obj.PractisePoints)
                    .Set(x => x.TopicName, obj.TopicName)
                    .Set(x => x.ConquestPoints, obj.ConquestPoints)
                    .Set(x => x.IsActive, obj.IsActive);
                _ITopicRepository.Update(query, update);
                rp.Success = true;
                rp.Message = "Cập nhật chủ đề thành công!";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }
    }
}
