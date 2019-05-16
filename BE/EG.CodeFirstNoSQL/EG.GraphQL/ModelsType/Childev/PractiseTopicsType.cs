using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class PractiseTopicsType : ObjectGraphType<PractiseTopic>
    {
        public PractiseTopicsType()
        {
            Field(x => x._id);
            Field(x => x.Topic_id);
            Field(x => x.Account_id);
            Field(x => x.ComleteDate);
            Field(x => x.CreatedDate);
            Field(x => x.IsComplete);
            Field(x => x.Note);
        }
    }
    public class PractiseTopicsPagedType : ObjectGraphType<PagedListModel<PractiseTopic>>
    {
        public PractiseTopicsPagedType()
        {
            Field<ListGraphType<PractiseTopicsType>>(
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
