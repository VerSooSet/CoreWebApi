using Domain.Abstractions;

namespace Domain.Exceptions
{
    public class UserLoginAlreadyExistsException: Exception, IDomainException
    {
        private const string DefaultMessage = "That Name of User already exists";
        public UserLoginAlreadyExistsException()
            : base(DefaultMessage)
        {
        }
    }
}
