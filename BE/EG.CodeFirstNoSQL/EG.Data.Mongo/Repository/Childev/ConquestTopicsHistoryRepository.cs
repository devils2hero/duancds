using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class ConquestTopicsHistoryRepository : RepositoryBase<ConquestTopicsHistory>, IConquestTopicsHistoryRepository
    {
        public ConquestTopicsHistoryRepository(DatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IConquestTopicsHistoryRepository : IRepository<ConquestTopicsHistory>
    {

    }
}
