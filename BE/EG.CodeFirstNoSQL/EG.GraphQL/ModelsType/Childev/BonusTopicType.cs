using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class BonusTopicType : ObjectGraphType<BonusTopic>
    {
        public BonusTopicType()
        {
            Field(x => x._id);
            Field(x => x.Account_id);
            Field(x => x.Topics_id);
            Field(x => x.DateStart);
            Field(x => x.DateEnd);
            Field(x => x.IsQualified);
            Field(x => x.Question_id);
        }
    }

   public class BonusTopicPagedType : ObjectGraphType<PagedListModel<BonusTopic>>
    {
        public BonusTopicPagedType()
        {
            Field<ListGraphType<BonusTopicType>>(
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
