using Domain.Abstractions;

namespace Domain.Exceptions
{
    public class UserNotFoundException : Exception, IDomainException
    {
        private const string DefaultMessage = "User not found";
        public UserNotFoundException()
            : base(DefaultMessage)
        {
        }
    }
}
