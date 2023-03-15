
namespace Command.Abstractions
{
    public interface IAsyncCommandFactory
    {
        IAsyncCommand<TCommandContex> Create<TCommandContex>() where TCommandContex : ICommandContext;
    }
}
