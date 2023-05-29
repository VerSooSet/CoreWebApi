using Domain.Abstractions;


namespace Domain.Exceptions
{
    public class ContentNotFoundException : Exception, IDomainException
    {
        private const string DefaultMessage = "Content not found";
        public ContentNotFoundException()
            : base(DefaultMessage)
        {
        }
    }
}
