using EG.Model.CustomModels.API;
using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class RoomType : ObjectGraphType<RoomCustom>
    {
        public RoomType()
        {
            Field(x => x._id);
            Field(x => x.Home_id);
            Field(x => x.Home_name);
            Field(x => x.Name);
            Field(x => x.Acreage);
            Field(x => x.IsUsed);
        }
    }

    public class RoomPagedType : ObjectGraphType<PagedListModel<RoomCustom>>
    {
        public RoomPagedType()
        {
            Field<ListGraphType<RoomType>>(
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
