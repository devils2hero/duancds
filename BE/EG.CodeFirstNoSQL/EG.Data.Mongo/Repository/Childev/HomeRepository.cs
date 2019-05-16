using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;

namespace EG.Data.Mongo.Repository.Childev
{ 
    public class HomeRepository : RepositoryBase<Home>, IHomeRepository
    {
        public HomeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IHomeRepository : IRepository<Home>
    {

    }
}
