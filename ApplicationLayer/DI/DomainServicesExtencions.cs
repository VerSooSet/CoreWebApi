using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain.DI
{
    public static class DomainServicesExtensions
    {
        public static IServiceCollection AddDomainServicesFromAssembly<T>(this IServiceCollection serviceCollection)
        {
            Assembly areaToSeek = typeof(T).Assembly;
            Type domainServiceType = typeof(IDomainService);

            Type[] domainServiceTypes = areaToSeek.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(domainServiceType))
                .ToArray();

            foreach (Type type in domainServiceTypes)
            {
                foreach (Type @interface in type.GetInterfaces().Where(x => x.IsAssignableTo(domainServiceType)))
                {
                    serviceCollection.AddScoped(@interface, type);
                }
            }

            return serviceCollection;
        }
    }
}
