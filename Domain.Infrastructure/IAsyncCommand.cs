namespace Command.Abstractions
{
    public interface IAsyncCommand<in TCommandContext> where TCommandContext: ICommandContext
    {
        Task ExecuteAsync(TCommandContext context, CancellationToken cancellationToken = default);
    }
}
