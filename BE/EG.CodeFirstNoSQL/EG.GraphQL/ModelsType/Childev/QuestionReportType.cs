using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class QuestionReportType : ObjectGraphType<QuestionReport>
    {
        public QuestionReportType()
        {
            Field(X => X._id);
            Field(x => x.Question_id);
            Field(x => x.Account_id);
            Field(x => x.Content);
            Field(x => x.CreatedDate);
        }
    }
    public class QuestionReportPagedType : ObjectGraphType<PagedListModel<QuestionReport>>
    {
        public QuestionReportPagedType()
        {
            Field<ListGraphType<QuestionReportType>>(
                "data",
                resolve: context => context.Source.Data
                );
            Field(x => x.PageIndex);
            Field(x => x.PageSize);
            Field(x => x.TotalItem);
            Field(x => x.TotalPage);
        }
    }
}
