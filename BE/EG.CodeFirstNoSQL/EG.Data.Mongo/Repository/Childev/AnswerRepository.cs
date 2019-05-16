using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class AnswerRepository : RepositoryBase<Answer>,IAnswerRepository
    {
        public AnswerRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IAnswerRepository : IRepository<Answer>
    {

    }
}
