using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace EG.Data.Mongo.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IClientSessionHandle Session { get; }
        void Add(T entity);
        void Add(IClientSessionHandle session, T entity);
        void Delete(FilterDefinition<T> filter);
        void Delete(IClientSessionHandle session, FilterDefinition<T> filter);
        void DeleteCollection(IClientSessionHandle session);
        IEnumerable<T> Get();
        T GetById(FilterDefinition<T> filter);
        void Update(FilterDefinition<T> filter, T entities);
        void Update(IClientSessionHandle session, FilterDefinition<T> filter, T entities);
        void Update(FilterDefinition<T> filter, UpdateDefinition<T> update);
        void Update(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update);
        IQueryable<T> Table { get; }
    }
}
