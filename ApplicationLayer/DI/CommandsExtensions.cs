using ApplicationLayer.DI.Factories;
using Command.Abstractions;
using Domain.Commands.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DI
{
    public static class CommandsExtensions
    {
        public static IServiceCollection AddCommandsFromAssembly<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAsyncCommandFactory, AsyncCommandFactory>();
            serviceCollection.AddScoped<IAsyncCommandBuilder, DefaultAsyncCommandBuilder>();

            Assembly areaToSeek = typeof(T).Assembly;
            Type commandTypeOpenGenericDefinition = typeof(IAsyncCommand<>);
            
            Type[] commandTypes = areaToSeek.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.GetInterfaces()
                    .Any(y => y.GetGenericTypeDefinition() is { } type && type == commandTypeOpenGenericDefinition))
                .ToArray();
            foreach (Type commandType in commandTypes)
            {
                Type[] interfaceTypes = commandType.GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() is { } type && type == commandTypeOpenGenericDefinition).ToArray();

                foreach (Type interfaceType in interfaceTypes)
                {
                    serviceCollection.AddScoped(interfaceType, commandType);
                }
            }
            return serviceCollection;
        }
    }
}
