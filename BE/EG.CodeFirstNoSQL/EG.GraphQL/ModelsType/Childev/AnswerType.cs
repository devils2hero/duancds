using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class AnswerType : ObjectGraphType<Answer>
    {
        public AnswerType()
        {
            Field(x => x._id);
            Field(x => x.Quesiton_id);
            Field(x => x.CorrectIndex);
            Field(x => x.Content);
            Field(x => x.ImagePath);
            Field(x => x.AudioPath);
            Field(x => x.IsActive);
            Field(x => x.CreatedDate);
        }
    }
    public class AnswerPagedType : ObjectGraphType<PagedListModel<Answer>>
    {
        public AnswerPagedType()
        {
            Field<ListGraphType<AnswerType>>(
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
