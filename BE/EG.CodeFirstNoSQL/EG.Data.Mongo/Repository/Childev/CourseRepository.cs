using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class CourseRepository :RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDatabaseFactory databaseFactory) :base(databaseFactory)
        {

        }
    }
    public interface ICourseRepository : IRepository<Course>
    {

    }
}
