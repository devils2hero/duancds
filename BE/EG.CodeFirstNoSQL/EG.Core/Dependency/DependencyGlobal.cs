using EG.Data.Mongo.Infrastructure;
using EG.Data.Mongo.Repository.Childev;
using EG.Graphql.ModelsType.Childev;
using EG.Graphql.Schemas;
using EG.Graphql.StoreMutations;
using EG.Graphql.StoreQuerys;
using EG.Service.Childev;
using EG.Web.Core.Helpers;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace EG.Core.Dependency
{
    public static class DependencyGlobal
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            //SQL
            //services.AddSingleton<IDatabaseFactory, DatabaseFactory>();
            //services.AddSingleton<IUnitOfWork, UnitOfWork>();
            //Mongo
            services.AddSingleton<IDatabaseFactory, DatabaseFactory>();
            services.AddSingleton<IDistributedCacheLayer, DistributedCacheLayer>();
            return services;
        }
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(typeof(HomeService).GetTypeInfo().Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
        public static IServiceCollection AddDependencyRepository(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(typeof(HomeRepository).GetTypeInfo().Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
        public static IServiceCollection AddDependencyGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.Scan(scan => scan
               .FromAssemblies(typeof(HomeType).GetTypeInfo().Assembly)
               .AddClasses()
               .AsSelf()
               .WithSingletonLifetime());
            services.Scan(scan => scan
               .FromAssemblies(typeof(HomePagedType).GetTypeInfo().Assembly)
               .AddClasses()
               .AsSelf()
               .WithSingletonLifetime());
            services.AddSingleton<StoreQuery>();
            services.AddSingleton<StoreMutation>();
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(_ => new StoreSchema(type => (GraphType)serviceProvider.GetService(type)) { Query = serviceProvider.GetService<StoreQuery>(), Mutation = serviceProvider.GetService<StoreMutation>() });     


            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            //services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            return services;
        }
    }
}
