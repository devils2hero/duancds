using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.System;

namespace EG.Data.Mongo.Repository.System
{
    public class System_RolesRepository : RepositoryBase<System_Roles>, ISystem_RolesRepository
    {
        public System_RolesRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ISystem_RolesRepository : IRepository<System_Roles>
    {

    }
}
