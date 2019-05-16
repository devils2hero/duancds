using Microsoft.Extensions.Options;
using EG.Model.CustomModels.ConnectionDatabase;
using MongoDB.Driver;

namespace EG.Data.Mongo.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MongoDatabaseEntities dataContext;
        private IClientSessionHandle sessionHandle;
        private readonly IOptions<MongoConnection> _OptionsAccessor;
        private readonly string ConnectionString = "";
        private readonly string Database = "";
        public MongoDatabaseEntities Get()
        {
            return dataContext ?? (dataContext = new MongoDatabaseEntities());
        }
        public IClientSessionHandle GetSession()
        {
            return sessionHandle ?? (sessionHandle = dataContext.Session);
        }
        public DatabaseFactory(IOptions<MongoConnection> _OptionsAccessor)
        {
            this._OptionsAccessor = _OptionsAccessor;
            ConnectionString = _OptionsAccessor.Value.Server;
            Database = _OptionsAccessor.Value.Database;
            if (ConnectionString == "" && Database == "")
            {
                dataContext = new MongoDatabaseEntities();
                //sessionHandle = dataContext.Session;
            }
            else
            {

                dataContext = new MongoDatabaseEntities(ConnectionString, Database);
                //sessionHandle = dataContext.Session;
            }
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
