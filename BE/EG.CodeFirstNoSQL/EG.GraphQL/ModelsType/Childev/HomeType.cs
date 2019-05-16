using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class HomeType : ObjectGraphType<Home>
    {
        public HomeType()
        {
            Field(x => x._id);
            Field(x => x.Name);
        }
    }
    public class HomePagedType : ObjectGraphType<PagedListModel<Home>>
    {
        public HomePagedType()
        {
            Field<ListGraphType<HomeType>>(
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
