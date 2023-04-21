using Database.N;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace Persistence.Queries
{
    public class FindUserByLoginQuery : IAsyncQuery<FindUserByLogin, User>
    {
        private readonly IDbCurrentTransactionProvider dbTransactionProvider;

        public FindUserByLoginQuery(IDbCurrentTransactionProvider _dbTransactionProvider)
        {
            this.dbTransactionProvider = _dbTransactionProvider ?? throw new ArgumentNullException(nameof(_dbTransactionProvider));
        }

        public async Task<User> AskAsync(FindUserByLogin criteria, CancellationToken cancellationToken = default)
        {
            /*DbTransaction transaction = await dbTransactionProvider.GetCurrentTransactionAsync(cancellationToken);
            System.Data.Common.DbConnection connection = transaction.Connection;

              FIXME (dapper)
             * return await connection.QuerySingleOrDefaultAsync<int>(@"SELECT Id,Login,CityId FROM User WHERE Login = @Login", new
            {
                Login = criteria.Login,
            }, transaction);
            */
            Console.WriteLine("Ask database find User by Login");

            return await Task.FromResult<User>(null);
        }
    }
}
