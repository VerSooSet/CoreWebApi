namespace Database.N
{
    public interface IDbConnectionFactory
    {
        Task<System.Data.Common.DbConnection> CreateConnectionAsync(CancellationToken token);
    }
}
