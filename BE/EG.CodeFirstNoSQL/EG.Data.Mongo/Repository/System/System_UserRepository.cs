using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.System;

namespace EG.Data.Mongo.Repository.System
{
    public class System_UserRepository : RepositoryBase<System_User>, ISystem_UserRepository
    {
        public System_UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }

    public interface ISystem_UserRepository : IRepository<System_User>
    {

    }
}
