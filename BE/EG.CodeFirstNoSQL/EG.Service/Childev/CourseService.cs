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
    public interface ICourseService
    {
        PagedListModel<Course> GetByPaged(string key, int PageNumber, int PageSize);
        /// <summary>
        /// Lấy danh sách khóa học mà tài khoản đã mua theo phân trang
        /// </summary>
        /// <param name="accountId">Id tài khoản người dùng</param>
        /// <param name="key">key lọc theo tên</param>
        /// <param name="PageNumber">Số trang hiện tại</param>
        /// <param name="PageSize">Số item trên trang</param>
        /// <returns>Data, Tổng Page, Tổng Item, Page hiện tại, Số Item trên page</returns>
        PagedListModel<Course> GetByPagedAccount(string accountId, string key, int PageNumber, int PageSize);
        IQueryable<Course> GetAll();
        Course GetById(string Id);
        MessageReport Create(Course obj);
        MessageReport Update(string _id, Course obj);
        MessageReport Delete(string _id);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _CourseRepository;
        private readonly IAccountCourseLogRepository _AccountCourseLogRepository;

        public CourseService(ICourseRepository _CourseRepository, IAccountCourseLogRepository _AccountCourseLogRepository)
        {
            this._CourseRepository = _CourseRepository;
            this._AccountCourseLogRepository = _AccountCourseLogRepository;
        }
        public PagedListModel<Course> GetByPaged(string key, int PageNumber, int PageSize)
        {
            var query = from n in _CourseRepository.Table
                        select n;
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(n => n.CourseName.Contains(key));
            }
            var data = new PagedList<Course>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Course>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }

        public Course GetById(string Id)
        {
            var filter = Builders<Course>.Filter.Eq(x => x._id, Id);
            var data = _CourseRepository.GetById(filter);
            return data;
        }

        public MessageReport Create(Course obj)
        {
            var report = new MessageReport();
            try
            {
                _CourseRepository.Add(obj);
                report.Success = true;
                report.Message = "Tạo khóa học thành công!";
            }
            catch (Exception ex)
            {
                report.Message = ex.Message;
            }
            return report;
        }

        public MessageReport Update(string _id, Course obj)
        {
            var report = new MessageReport();
            try
            {
                var query = Builders<Course>.Filter.Eq(e => e._id, _id);
                var update = Builders<Course>.Update
                    .Set(x => x.CourseName, obj.CourseName)
                    .Set(x => x.PrerequisiteCourse, obj.PrerequisiteCourse)
                    .Set(x => x.Description, obj.Description)
                    .Set(x => x.ImagePath, obj.ImagePath)
                    .Set(x => x.Background, obj.Background)
                    .Set(x => x.Price, obj.Price)
                    .Set(x => x.CreatedBy, obj.CreatedBy)
                    .Set(x => x.ModifiedDate, obj.ModifiedDate)
                    .Set(x => x.ModifiedBy, obj.ModifiedBy)
                    .Set(x => x.IsActive, obj.IsActive);
                _CourseRepository.Update(query, update);
                report.Success = true;
                report.Message = "Cập nhật khóa học thành công!";

            }
            catch (Exception ex)
            {
                report.Message = ex.Message;
            }
            return report;
        }

        public MessageReport Delete(string _id)
        {
            var rp = new MessageReport();
            try
            {
                var query = Builders<Course>.Filter.Eq(a => a._id, _id);
                _CourseRepository.Delete(query);
                rp.Success = true;
                rp.Message = "Xoá thành công khóa học";
            }
            catch (Exception ex)
            {
                rp.Message = ex.Message;
            }
            return rp;
        }

        public IQueryable<Course> GetAll()
        {

            var query = from n in _CourseRepository.Table
                        select n;
            return query;
        }

        public PagedListModel<Course> GetByPagedAccount(string accountId, string key, int PageNumber, int PageSize)
        {
            var query = from n in _CourseRepository.Table
                        join acl in _AccountCourseLogRepository.Table on n._id equals acl.Course_id
                        where acl.Account_id.Equals(accountId)
                        select new Course()
                        {
                            Background = n.Background,
                            PrerequisiteCourse = n.PrerequisiteCourse,
                            CourseName = n.CourseName,
                            CreatedDate = n.CreatedDate,
                            Description = n.Description,
                            ImagePath = n.ImagePath,
                            Price = n.Price,
                            IsActive = n.IsActive,
                            CreatedBy = n.CreatedBy,
                            ModifiedBy = n.ModifiedBy,
                            ModifiedDate = n.ModifiedDate,
                            _id = n._id
                        };
            if (!string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(n => n.CourseName.Contains(key));
            }
            var data = new PagedList<Course>(query.OrderBy(n => n._id), PageNumber, PageSize);
            var pagedList = PageModelCustom<Course>.GetPage(data, PageNumber, PageSize);
            return pagedList;
        }
    }
}
