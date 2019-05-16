using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.System;

namespace EG.Data.Mongo.Repository.System
{
    public class System_APIRepository : RepositoryBase<System_API>, ISystem_APIRepository
    {
        public System_APIRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ISystem_APIRepository : IRepository<System_API>
    {

    }
}
