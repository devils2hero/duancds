using EG.Graphql.StoreMutations;
using EG.Graphql.StoreQuerys;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.Schemas
{
    public class StoreSchema : Schema
    {
        public StoreSchema(Func<Type, GraphType> resolveType)
        {
            Query = (StoreQuery)resolveType(typeof(StoreQuery));
            Mutation = (StoreMutation)resolveType(typeof(StoreMutation));
        }
    }
    //public class AccountSchema : Schema
    //{
    //    public AccountSchema(Func<Type, GraphType> resolveType)
    //    {
    //        Query = (StoreQuery)resolveType(typeof(StoreQuery));
    //        Mutation = (StoreMutation)resolveType(typeof(StoreMutation));
    //    }
    //}
}
