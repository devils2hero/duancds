using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class ConquestTopicsHistoryType : ObjectGraphType<ConquestTopicsHistory>
    {
        public ConquestTopicsHistoryType()
        {
            Field(x => x._id);
            Field(x => x.Question_id);
            Field(x => x.ConquestTopics_id);
        }
    }
    public class ConquestTopicsHistoryPagedType : ObjectGraphType<PagedListModel<ConquestTopicsHistory>>
    {
        public ConquestTopicsHistoryPagedType()
        {
            Field<ListGraphType<ConquestTopicsHistoryType>>(
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
