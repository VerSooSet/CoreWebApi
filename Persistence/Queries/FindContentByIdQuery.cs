using Database.N;
using Domain.Criteria;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace Persistence.Queries
{
    public class FindContentByIdQuery : IAsyncQuery<FindById, Content>
    {
        private readonly IDbCurrentTransactionProvider dbCurrentTransactionProvider;

        public async Task<Content> AskAsync(FindById criteria, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(
                String.Format(
                    "[{0}] Ask database find Content by Id",
                    DateTime.Now.ToShortTimeString()
                )
            );
            return await Task.FromResult<Content>(null);
        }

        public FindContentByIdQuery(IDbCurrentTransactionProvider dbCurrentTransactionProvider)
        {
            this.dbCurrentTransactionProvider = dbCurrentTransactionProvider;
        }

    }
}
