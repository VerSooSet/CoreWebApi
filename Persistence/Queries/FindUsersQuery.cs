using Database.N;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace Persistence.Queries
{
    public class FindUsersQuery: IAsyncQuery<FindUsers,List<User>>
    {
        private readonly IDbCurrentTransactionProvider dbTransactionProvider;

        public FindUsersQuery(IDbCurrentTransactionProvider _dbTransactionProvider)
        {
            this.dbTransactionProvider = _dbTransactionProvider ?? throw new ArgumentNullException(nameof(_dbTransactionProvider));
        }

        public async Task<List<User>> AskAsync(FindUsers criteria, CancellationToken cancellationToken = default)
        {
            /*DbTransaction transaction = await dbTransactionProvider.GetCurrentTransactionAsync(cancellationToken);
            System.Data.Common.DbConnection connection = transaction.Connection;
            */
            Console.WriteLine("Ask db for taking list of all Users");
            return await Task.FromResult<List<User>>(new List<User>());
        }
    }
}
