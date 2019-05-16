using EG.Graphql.ModelsType.Childev;
using EG.Service.Childev;
using GraphQL.Types;

namespace EG.Graphql.StoreQuerys.Childev
{
    public class RoomStoreQuery : CustomLib.Types.ObjectGraphTypeCustom
    {
        public RoomStoreQuery(IRoomService _RoomService)
        {
            Field<RoomPagedType>(
                name: "rooms",
                description: "",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Home_id", Description = "Home Id", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "key", Description = "key", DefaultValue = "" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "pageNumber", DefaultValue = 1 },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "pageSize", DefaultValue = 20 }
                ),
                resolve: context => _RoomService.GetByPaged(context.GetArgument<string>("Home_id"), context.GetArgument<string>("key"), context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize"))
            );

            Field<RoomType>(
                    name: "room",
                    description: "",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "_id", Description = "Room Id", DefaultValue = "" }
                    ),
                    resolve: context => _RoomService.GetById(context.GetArgument<string>("_id"))
                );
        }
    }
}
