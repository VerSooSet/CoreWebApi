using Command.Abstractions;
using Domain.Entitiyes;


namespace Domain.Commands.Contexts
{
    public class CreateUserCommandContext: ICommandContext
    {
        public CreateUserCommandContext(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public User User { get; }

    }
}
