using EG.Data.Mongo.Infrastructure;
using EG.Model.Models.Childev;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Data.Mongo.Repository.Childev
{
    public class QuestionReportRepository : RepositoryBase<QuestionReport> , IQuestionReportRepository
    {
        public QuestionReportRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
    public interface IQuestionReportRepository : IRepository<QuestionReport>
    {

    }
}
