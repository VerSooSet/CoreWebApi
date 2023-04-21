using Queries.Abstractions;

namespace Domain.Criteria
{
    public class FindUserByLogin: ICriterion
    {
        public FindUserByLogin(string login)
        {
            Login = login;
        }

        public string Login { get; }
    }
}
