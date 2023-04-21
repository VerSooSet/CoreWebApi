namespace Queries.Abstractions
{
    public class DefaultAsyncQueryFor<TResult>: IAsyncQueryFor<TResult>
    {
        private readonly IAsyncQueryFactory _asyncQueryFactory;

        public DefaultAsyncQueryFor(IAsyncQueryFactory asyncqueryFactory) 
        {
            this._asyncQueryFactory = asyncqueryFactory;
        }

        public Task<TResult> WithAsync<TCriterion>(
            TCriterion criteria,
            CancellationToken cancellationToken = default
            ) where TCriterion : ICriterion
        {
            return _asyncQueryFactory.Create<TCriterion, TResult>().AskAsync(criteria, cancellationToken);
        }

    }
}
