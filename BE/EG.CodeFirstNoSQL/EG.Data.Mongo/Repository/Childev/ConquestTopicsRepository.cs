using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class ConquestTopicsRepository : RepositoryBase<ConquestTopic> , IConquestTopicsRepository
    {
        public ConquestTopicsRepository(DatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IConquestTopicsRepository : IRepository<ConquestTopic>
    {

    }
}
