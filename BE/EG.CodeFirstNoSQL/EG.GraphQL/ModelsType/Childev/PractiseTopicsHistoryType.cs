using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class PractiseTopicsHistoryType : ObjectGraphType<PractiseTopicsHistory>
    {
        public PractiseTopicsHistoryType()
        {
            Field(x => x._id);
            Field(x => x.Question_id);
            Field(x => x.PractiseTopics_id);
        }
    }
    public class PractiseTopicsHistoryPagedType : ObjectGraphType<PagedListModel<PractiseTopicsHistory>>
    {
        public PractiseTopicsHistoryPagedType()
        {
            Field<ListGraphType<PractiseTopicsHistoryType>>(
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
