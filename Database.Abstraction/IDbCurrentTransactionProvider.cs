using System.Data.Common;

namespace Database.N
{
    public interface IDbCurrentTransactionProvider
    {
        Task<DbTransaction> GetCurrentTransactionAsync(CancellationToken cancellationToken = default);
    }
}
