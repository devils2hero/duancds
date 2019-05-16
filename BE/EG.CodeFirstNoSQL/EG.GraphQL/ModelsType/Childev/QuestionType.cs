using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class QuestionType : ObjectGraphType<Question>
    {
           public QuestionType()
        {
            Field(x => x._id);
            Field(x => x.Topic_id);
            Field(x => x.Title);
            Field(x => x.Content);
            Field(x => x.ImagePath);
            Field(x => x.AudioPath);
            Field(x => x.IsActive);
            Field(x => x.CreatedDate);
        }
    }
    public class QuestionPagedType : ObjectGraphType<PagedListModel<Question>>
    {
        public QuestionPagedType()
        {
            Field<ListGraphType<QuestionType>>(
                "data",
                resolve:context => context.Source.Data
                );
            Field(x => x.PageIndex);
            Field(x => x.PageSize);
            Field(x => x.TotalItem);
            Field(x => x.TotalPage);
        }
    }
}
