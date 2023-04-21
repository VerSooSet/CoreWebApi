using Database.Abstraction;
using Database.N;
using Domain.Initializers;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.DI
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase<TDbConnectionFactory,TDbTransactionProvider>(this IServiceCollection serviceCollection)
            where TDbConnectionFactory: class, IDbConnectionFactory
            where TDbTransactionProvider: class,IDbCurrentTransactionProvider
        {
            serviceCollection.AddSingleton<IDbConnectionFactory, TDbConnectionFactory>();
            serviceCollection.AddScoped<IDbCurrentTransactionProvider, TDbTransactionProvider>();
            
            return serviceCollection;
        }
    }
}
