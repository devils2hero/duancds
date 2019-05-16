using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
          public EventRepository(DatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IEventRepository : IRepository<Event>
    {

    }
}
