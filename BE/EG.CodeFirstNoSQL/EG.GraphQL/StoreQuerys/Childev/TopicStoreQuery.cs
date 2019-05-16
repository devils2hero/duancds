using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class TopicStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public TopicStoreQuery(ITopicService _TopicService)
        {
            Field<TopicPagedType>(
                name: "topics",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "account_id", Description = "Account Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "course_id", Description = "Course Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _TopicService.GetByPagedAccount(context.GetArgument<string>("account_id"), context.GetArgument<string>("course_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<TopicType>(
                    name: "topic",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Topic Id", DefaultValue = "" }
                    ),
                    resolve: context => _TopicService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
