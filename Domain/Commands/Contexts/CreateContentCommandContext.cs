using Command.Abstractions;
using Domain.Entitiyes;


namespace Domain.Commands.Contexts
{
    public class CreateContentCommandContext: ICommandContext
    {
        public CreateContentCommandContext(Content content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public Content Content { get; }

    }
}
