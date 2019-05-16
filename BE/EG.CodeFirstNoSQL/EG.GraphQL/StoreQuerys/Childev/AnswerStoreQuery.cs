using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class AnswerStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public AnswerStoreQuery(IAnswerService _AnswerService)
        {
            Field<AnswerPagedType>(
                name: "answers",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Question_id", Description = "Question Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _AnswerService.GetByPaged(context.GetArgument<string>("Topic_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<AnswerType>(
                    name: "answer",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Answer Id", DefaultValue = "" }
                    ),
                    resolve: context => _AnswerService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
