using Database.Abstraction;
using System.Data.Common;


namespace Database.N
{
    public class DbTransactionProvider : IDbCurrentTransactionProvider, IDisposable
    {
        private bool _disposed;
        private DbConnection _connection;
        private DbTransaction _transaction;
        private readonly IDbConnectionFactory _connectionFactory;
        public DbTransactionProvider(IDbConnectionFactory factory)
        {
            _connectionFactory = factory;
        }

        public async Task<DbTransaction> GetCurrentTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(DbTransactionProvider));
            if (_transaction != null)
                return _transaction;

            
            _connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            _transaction = await _connection.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
            return _transaction;
        }

        #region IDisposable implementation
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;

            if (disposing)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~DbTransactionProvider() => Dispose(false);

    }
}
