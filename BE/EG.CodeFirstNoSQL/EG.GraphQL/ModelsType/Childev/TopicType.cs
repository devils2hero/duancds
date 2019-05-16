using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class TopicType: ObjectGraphType<Topic>
    {
       public TopicType()
        {
            Field(x => x._id);
            Field(x => x.Course_id);
            Field(x => x.TopicName);
            Field(x => x.Description);
            Field(x => x.ImagePath);
            Field(x => x.Background);
            Field(x => x.NumberOfPraticeDays);
            Field(x => x.ConquestPoints);
            Field(x => x.PractisePoints);
            Field(x => x.BonusPoints);
            Field(x => x.IsActive);
            Field(x => x.CreatedDate);
        }
    }
    public class TopicPagedType : ObjectGraphType<PagedListModel<Topic>>
    {
        public TopicPagedType()
        {
            Field<ListGraphType<TopicType>>(
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
