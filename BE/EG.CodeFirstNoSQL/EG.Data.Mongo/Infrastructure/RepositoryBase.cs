using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace EG.Data.Mongo.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private MongoDatabaseEntities dataContext;
        private IMongoCollection<T> context;
        private IClientSessionHandle sessionHandle;
        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            context = DataContext.GetCollection<T>();
            //sessionHandle = DataContext.Session;
        }
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        public IClientSessionHandle Session => sessionHandle ?? (sessionHandle = DatabaseFactory.GetSession());
        protected MongoDatabaseEntities DataContext => dataContext ?? (dataContext = DatabaseFactory.Get());

        public void Add(T entity)
        {
            context.InsertOne(entity);
        }
        public void Add(IClientSessionHandle session, T entity)
        {
            context.InsertOne(session, entity);
        }

        public void Delete(FilterDefinition<T> filter)
        {
            context.DeleteOne(filter);
        }
        public void Delete(IClientSessionHandle session, FilterDefinition<T> filter)
        {
            context.DeleteOne(session, filter);
        }
        
        public void DeleteCollection(IClientSessionHandle session)
        {
            context.DeleteMany(session, x => true);
        }

        public IEnumerable<T> Get()
        {
            return this.Table;
        }
        public T GetById(FilterDefinition<T> filter)
        {
            return context.Find(filter).FirstOrDefault();
        }
        public void Update(FilterDefinition<T> filter, T entities)
        {
            context.FindOneAndReplace(filter, entities);
        }
        public void Update(IClientSessionHandle session, FilterDefinition<T> filter, T entities)
        {
            context.FindOneAndReplace(session, filter, entities);
        }
        public void Update(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            context.UpdateOne(filter, update);
        }
        public void Update(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            context.UpdateOne(session, filter, update);
        }


        public IQueryable<T> Table => context.AsQueryable();
    }
}
