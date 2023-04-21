namespace Queries.Abstractions
{
    public interface IAsyncQuery<in TCriterion,TResult> where TCriterion: ICriterion
    {
        Task<TResult> AskAsync(TCriterion criteria, CancellationToken cancellationToken = default);
    }
}
