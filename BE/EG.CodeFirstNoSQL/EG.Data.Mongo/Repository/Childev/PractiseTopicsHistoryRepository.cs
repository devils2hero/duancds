using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class PractiseTopicsHistoryRepository : RepositoryBase<PractiseTopicsHistory>, IPractiseTopicsHistoryRepository
    {
       public PractiseTopicsHistoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IPractiseTopicsHistoryRepository : IRepository<PractiseTopicsHistory>
    {

    }
}
