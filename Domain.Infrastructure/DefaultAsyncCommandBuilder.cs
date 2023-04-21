namespace Command.Abstractions
{
    public class DefaultAsyncCommandBuilder : IAsyncCommandBuilder
    {
        private readonly IAsyncCommandFactory _asyncCommandFactory;
        public DefaultAsyncCommandBuilder(IAsyncCommandFactory factory)
        {
            _asyncCommandFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public Task DeleteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommandFactory.Create<TCommandContext>().ExecuteAsync(context, cancellationToken);
        }

        public Task ExecuteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken=default) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommandFactory.Create<TCommandContext>().ExecuteAsync(context, cancellationToken);
        }

        public Task UpdateAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommandFactory.Create<TCommandContext>().ExecuteAsync(context, cancellationToken);
        }
    }
}
