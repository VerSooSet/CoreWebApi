namespace Command.Abstractions
{
    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken = default) where TCommandContext: ICommandContext;
        Task UpdateAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext;
        Task DeleteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext;
    }
}
