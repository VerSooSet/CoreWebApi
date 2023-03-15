using System.Data.Common;
using System.Data.SqlClient;
using Database.Abstraction;

namespace Database.N
{
    /// <summary>Создание соединения, открытие его и возвращение экземпляра.</summary>
    public class MSSQLConnectionFactory : IDbConnectionFactory
    {
        //private readonly IOptions<MSSQLConnectionFactoryOptions> _options;
        private readonly string _connectionString;
        public MSSQLConnectionFactory(string ConnectionString)
        {
            //_options = options ?? throw new ArgumentNullException(nameof(options));
            _connectionString = ConnectionString;
        }

        public async Task<System.Data.Common.DbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
        {
            DbConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellationToken);
            return conn;
        }
    }
}
