using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev

{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x._id);
            Field(x => x.Username);
            Field(x => x.Gender);
            Field(x => x.Name);
            Field(x => x.Address);
            Field(x => x.IsActive);
        }
    }
    public class AccountPagedType : ObjectGraphType<PagedListModel<Account>>
    {
        public AccountPagedType()
        {
            Field<ListGraphType<AccountType>>(
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
