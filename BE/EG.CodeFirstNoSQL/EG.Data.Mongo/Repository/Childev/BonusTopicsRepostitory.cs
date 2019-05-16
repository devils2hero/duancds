using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class BonusTopicsRepostitory : RepositoryBase<BonusTopic>, IBonusTopicsRepository
    {
        public BonusTopicsRepostitory(DatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }

    public interface IBonusTopicsRepository : IRepository<BonusTopic>
    {

    }
}
