using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.System;

namespace EG.Data.Mongo.Repository.System
{
    public class System_RoleAPIRepository : RepositoryBase<System_RoleAPI>, ISystem_RoleAPIRepository
    {
        public System_RoleAPIRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ISystem_RoleAPIRepository : IRepository<System_RoleAPI>
    {

    }
}
