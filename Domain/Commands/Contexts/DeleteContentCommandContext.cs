using Command.Abstractions;
using Domain.Entitiyes;

namespace Domain.Commands.Contexts
{
    public class DeleteContentCommandContext: ICommandContext
    {
        public DeleteContentCommandContext(Content content)
        { 
            Content= content ?? throw new ArgumentNullException(nameof(content));
        }

        Content Content { get; set; }
    }
}
