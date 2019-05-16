using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class AccountCourseLogType : ObjectGraphType<AccountCourseLog>
    {
        public AccountCourseLogType()
        {
            Field(x => x._id);
            Field(x => x.Course_id);
            Field(x => x.CreatedDate);
            Field(x => x.IsActive);
            Field(x => x.Account_id);
        }
    }
    public class AccountCourseLogPagedType : ObjectGraphType<PagedListModel<AccountCourseLog>>
    {
        public AccountCourseLogPagedType()
        {
            Field<ListGraphType<AccountCourseLogType>>(
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
