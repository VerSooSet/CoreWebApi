using Command.Abstractions;
using global::Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.DI.Factories
{
    public class AsyncCommandFactory : IAsyncCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;
        
        public AsyncCommandFactory(IServiceProvider provider)
        {
            _serviceProvider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IAsyncCommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext
        {
            var command = _serviceProvider.GetService<IAsyncCommand<TCommandContext>>();
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            return command;
        }
    }
}
