using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.System;

namespace EG.Data.Mongo.Repository.System
{
    public class System_UserRoleRepository : RepositoryBase<System_UserRole>, ISystem_UserRoleRepository
    {
        public System_UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface ISystem_UserRoleRepository : IRepository<System_UserRole>
    {

    }
}
