using Domain.Abstractions;

namespace Domain.Exceptions
{
    public class UserLoginAlreadyExistsException: Exception, IDomainException
    {
        private const string DefaultMessage = "That name string already exists in db";
        public UserLoginAlreadyExistsException()
            : base(DefaultMessage)
        {
        }
    }
}
