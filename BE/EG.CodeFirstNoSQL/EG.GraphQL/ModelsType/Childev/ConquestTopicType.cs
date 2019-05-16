using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class ConquestTopicType : ObjectGraphType<ConquestTopic>
    {
        public ConquestTopicType()
        {
            Field(x => x._id);
            Field(x => x.Topics_id);
            Field(x => x.Account_id);
            Field(x => x.Note);
            Field(x => x.CreatedDate);
            Field(x => x.IsComplete);
            Field(x => x.CompleteDate);
        }
    }
    public class ConquestTopicPagedType : ObjectGraphType<PagedListModel<ConquestTopic>>
    {
        public ConquestTopicPagedType()
        {
            Field<ListGraphType<ConquestTopicType>>(
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
