using ApplicationLayer.DI.Factories;
using Queries.Abstractions;
using System.Data;
using System.Reflection;

namespace ApplicationLayer.DI
{
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueriesFromAssembly<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IAsyncQueryFor<>), typeof(DefaultAsyncQueryFor<>));
            serviceCollection.AddScoped<IAsyncQueryFactory, AsyncQueryFactory>();
            serviceCollection.AddScoped<IAsyncQueryBuilder, AsyncQueryBuilder>();

            Assembly assembly = typeof(T).Assembly;
            Type queryTypeOpenGenericDefinition = typeof(IAsyncQuery<,>);

            Type[] queryTypes = assembly.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.GetInterfaces()
                    .Any(y => y.GetGenericTypeDefinition() is { } type && type == queryTypeOpenGenericDefinition))
                .ToArray();
            foreach (Type queryType in queryTypes)
            {
                Type[] interfaceTypes = queryType.GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() is { } type && type == queryTypeOpenGenericDefinition)
                    .ToArray();
                
                foreach (Type interfaceType in interfaceTypes)
                {
                    serviceCollection.AddTransient(interfaceType, queryType);
                }
            }
            return serviceCollection;
        }
    }
}
