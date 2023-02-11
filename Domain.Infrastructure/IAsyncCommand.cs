namespace Transcactions
{
    public interface IAsyncCommand<in TCommandContext> where TCommandContext: ICommandContext
    {
        Task ExecuteAsync(ICommandContext context, CancellationToken token);
    }
}
