using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class HomeStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public HomeStoreQuery(IHomeService _HomeService)
        {
            Field<HomePagedType>(
                name: "homes",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _HomeService.GetByPaged(context.GetArgument<string>("_id"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<HomeType>(
                    name: "home",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Home Id", DefaultValue = "" }
                    ),
                    resolve: context => _HomeService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
