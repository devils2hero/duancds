using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class QuestionStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public QuestionStoreQuery(IQuestionService _QuestionService)
        {
            Field<QuestionPagedType>(
                name: "questions",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Topic_id", Description = "Topic Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _QuestionService.GetByPaged(context.GetArgument<string>("Topic_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<QuestionType>(
                    name: "question",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Question Id", DefaultValue = "" }
                    ),
                    resolve: context => _QuestionService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
