using MongoDB.Driver;
using System;

namespace EG.Data.Mongo.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        MongoDatabaseEntities Get();
        IClientSessionHandle GetSession();
    }
}
