using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType()
        {
            Field(x => x._id);
            Field(x => x.Account_id);
            Field(x => x.Bonus);
            Field(x => x.ContentEvent);
            Field(x => x.TimeStart);
            Field(x => x.TimeEnd);
            Field(x => x.Result);
        }
    }
    public class EventPagedType : ObjectGraphType<PagedListModel<Event>>
    {
        public EventPagedType()
        {
            Field<ListGraphType<EventType>>(
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
