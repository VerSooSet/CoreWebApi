using System.Data.Common;
using System.Data.SqlClient;
using Database.Abstraction;
using Microsoft.Extensions.Options;

namespace Database.N
{
    /// <summary>Создание соединения, открытие его и возвращение экземпляра.</summary>
    public class MSSQLConnectionFactory : IDbConnectionFactory
    {
        private readonly IOptions<MSSQLConnectionFactoryOptions> _options;
        
        [Obsolete]
        public MSSQLConnectionFactory() { }
        public MSSQLConnectionFactory(IOptions<MSSQLConnectionFactoryOptions> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<System.Data.Common.DbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
        {
            DbConnection conn = new SqlConnection(_options.Value.ConnectionString);
            await conn.OpenAsync(cancellationToken);
            return conn;
        }
    }
}
