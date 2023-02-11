namespace Transcactions
{
    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) where TCommandContext: ICommandContext;
        Task UpdateAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) where TCommandContext : ICommandContext;
        Task DeleteAsync<TCommandContext>(
            TCommandContext context, 
            CancellationToken cancellationToken) where TCommandContext : ICommandContext;
    }
}
