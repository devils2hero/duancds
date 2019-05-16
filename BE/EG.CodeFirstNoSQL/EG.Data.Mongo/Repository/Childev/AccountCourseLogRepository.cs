using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class AccountCourseLogRepository : RepositoryBase<AccountCourseLog>, IAccountCourseLogRepository
    {
        public AccountCourseLogRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
   
    }
    public interface IAccountCourseLogRepository : IRepository<AccountCourseLog>
    {

    }
}
