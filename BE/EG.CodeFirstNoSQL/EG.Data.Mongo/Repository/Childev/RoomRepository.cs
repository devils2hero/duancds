using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;

namespace EG.Data.Mongo.Repository.Childev
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IRoomRepository : IRepository<Room>
    {

    }
}
