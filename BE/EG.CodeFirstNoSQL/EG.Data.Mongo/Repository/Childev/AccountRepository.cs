using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IAccountRepository : IRepository<Account>
    {

    }
}
