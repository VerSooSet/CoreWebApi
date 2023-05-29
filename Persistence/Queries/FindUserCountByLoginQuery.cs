using Database.N;
using Domain.Criteria;
using Queries.Abstractions;

namespace Persistence.Queries
{
    public class FindUserCountByLoginQuery: IAsyncQuery<FindUsersCountByLogin, int>
    {
        private readonly IDbCurrentTransactionProvider dbTransactionProvider;

        public FindUserCountByLoginQuery(IDbCurrentTransactionProvider _dbTransactionProvider) 
        {
            this.dbTransactionProvider = _dbTransactionProvider ?? throw new ArgumentNullException(nameof(_dbTransactionProvider));
        }

        public async Task<int> AskAsync(FindUsersCountByLogin criteria, CancellationToken cancellationToken = default)
        {
            /*DbTransaction transaction = await dbTransactionProvider.GetCurrentTransactionAsync(cancellationToken);
            System.Data.Common.DbConnection connection = transaction.Connection;

              FIXME (dapper)
             * return await connection.QuerySingleOrDefaultAsync<int>(@"SELECT count(Id) FROM User WHERE Login = @Login", new
            {
                Login = criteria.Login,
            }, transaction);
            */
            Console.WriteLine(
                String.Format(
                    "[{0}] Ask database for Users counts",
                    DateTime.Now.ToShortTimeString()
                )
            );

            return await Task.FromResult<int>(0);
        }
    }
}
