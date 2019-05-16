using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class PractiseTopicStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public PractiseTopicStoreQuery(IPractiseTopic _PractiseTopic)
        {
            Field<PractiseTopicsPagedType>(
                name: "pratisetopics",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Topic_id", Description = "Topic Id", DefaultValue = "" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Account_id", Description = "Account Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _PractiseTopic.GetByPaged(context.GetArgument<string>("Topic_id"), context.GetArgument<string>("Account_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<PractiseTopicsType>(
                    name: "pratisetopic",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "PractiseTopic Id", DefaultValue = "" }
                    ),
                    resolve: context => _PractiseTopic.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
