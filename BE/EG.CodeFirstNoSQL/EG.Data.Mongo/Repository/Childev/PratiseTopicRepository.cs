using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class PratiseTopicRepository : RepositoryBase<PractiseTopic>, IPratiseTopicRepository
    {
        public PratiseTopicRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

    }
    public interface IPratiseTopicRepository : IRepository<PractiseTopic>
    {

    }
}
