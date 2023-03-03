using System.Data.Common;

namespace Database.N
{
    public interface IDBProvider
    {
        Task<DbTransaction> GetCurrentTransactionAsync(CancellationToken cancellationToken = default);
    }
}
