using Database.N;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace Persistence.Queries
{
    public class FindContentsQuery : IAsyncQuery<FindContentItems, List<Content>>
    {
        private readonly IDbCurrentTransactionProvider dbTransactionProvider;

        public FindContentsQuery(IDbCurrentTransactionProvider dbTransactionProvider)
        {
            this.dbTransactionProvider = dbTransactionProvider;
        }

        public async Task<List<Content>> AskAsync(FindContentItems criteria, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(
                String.Format(
                    "[{0}] Ask db for taking list of all Contents",
                    DateTime.Now.ToShortTimeString()
                )
            );
            return await Task.FromResult<List<Content>>(new List<Content>());
        }
    }
}
