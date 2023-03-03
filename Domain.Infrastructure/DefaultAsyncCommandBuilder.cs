namespace Command.Abstractions
{
    public class DefaultAsyncCommandBuilder : IAsyncCommandBuilder
    {
        private readonly IAsyncCommand<ICommandContext> _asyncCommand;
        public DefaultAsyncCommandBuilder(IAsyncCommand<ICommandContext> command)
        {
            _asyncCommand = command ?? throw new ArgumentNullException(nameof(command));
        }

        public Task DeleteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommand.ExecuteAsync(context, cancellationToken);
        }

        public Task ExecuteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken=default) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommand.ExecuteAsync(context, cancellationToken);
        }

        public Task UpdateAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) 
            where TCommandContext : ICommandContext
        {
            return _asyncCommand.ExecuteAsync(context, cancellationToken);
        }
    }
}
