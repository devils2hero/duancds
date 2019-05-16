using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace EG.Data.Mongo
{
    public class MongoDatabaseEntities
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IClientSessionHandle _session;
        public MongoDatabaseEntities()
        {

        }
        public MongoDatabaseEntities(string Connection, string Database)
        {
            _client = new MongoClient(Connection);
            _session = _client.StartSession();
            _db = _session.Client.GetDatabase(Database);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name);
        }
        public IClientSessionHandle Session => _session ?? _client.StartSession();
        public void Dispose()
        {
            _session.Dispose();
        }

    }
}
