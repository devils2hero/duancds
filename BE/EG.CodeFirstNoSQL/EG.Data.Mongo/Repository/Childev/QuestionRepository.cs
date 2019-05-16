using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

    }
    public interface IQuestionRepository : IRepository<Question>
    {

    }
}
