using Command.Abstractions;
using Domain.Entitiyes;

namespace Domain.Commands.Contexts
{
    public class DeleteUserCommandContext: ICommandContext
    {
        public DeleteUserCommandContext(User user) 
        {
           User = user ?? throw new ArgumentNullException(nameof(user));
        }
        
        public User User { get; }

    }
}
