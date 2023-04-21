using Database.N;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;


namespace Persistence.Queries
{
    public class FindUserByIdQuery : IAsyncQuery<FindById, User>
    {
        private readonly IDbCurrentTransactionProvider dbTransactionProvider;

        public FindUserByIdQuery(IDbCurrentTransactionProvider _dbTransactionProvider)
        {
            this.dbTransactionProvider = _dbTransactionProvider ?? throw new ArgumentNullException(nameof(_dbTransactionProvider));
        }

        public async Task<User> AskAsync(FindById criteria, CancellationToken cancellationToken = default)
        {
            /*DbTransaction transaction = await dbTransactionProvider.GetCurrentTransactionAsync(cancellationToken);
            System.Data.Common.DbConnection connection = transaction.Connection;

              FIXME (dapper)
             * return await connection.QuerySingleOrDefaultAsync<int>(@"SELECT count(Id) FROM User WHERE Login = @Login", new
            {
                Login = criteria.Login,
            }, transaction);
            */
            Console.WriteLine("Ask database find User by Id");

            return await Task.FromResult<User>(null);
        }
    }
}
