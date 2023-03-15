using System.Data.Common;

namespace Database.Abstraction
{
    public interface IDbConnectionFactory
    {
        // Создание открытого готового к применению соединения с бд   
        Task<DbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
    }
}
