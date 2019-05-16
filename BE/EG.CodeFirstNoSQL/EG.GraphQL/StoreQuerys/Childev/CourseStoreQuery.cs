using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class CourseStoreQuery : ObjectGraphType
    {
        public CourseStoreQuery(ICourseService _CourseService)
        {
            //Field<CoursePagedType>(
            //    name: "courses",
            //    description: "",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
            //        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
            //        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
            //    ),
            //    resolve: context => _CourseService.GetByPaged(context.GetArgument<string>("_id"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            //);

            Field<CoursePagedType>(
                name: "courses",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "account_id", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _CourseService.GetByPagedAccount(context.GetArgument<string>("account_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<CourseType>(
                    name: "course",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Course Id", DefaultValue = "" }
                    ),
                    resolve: context => _CourseService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
