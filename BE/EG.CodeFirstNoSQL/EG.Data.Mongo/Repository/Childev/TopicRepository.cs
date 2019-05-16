using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
   public class TopicRepository : RepositoryBase<Topic> , ITopicRepository
    {
        public TopicRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ITopicRepository : IRepository<Topic>
    {

    }
}
