using Queries.Abstractions;

namespace ApplicationLayer.DI.Factories
{
    public class AsyncQueryFactory : IAsyncQueryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AsyncQueryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IAsyncQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion
        {
            return _serviceProvider.GetService<IAsyncQuery<TCriterion, TResult>>();
        }
    }
}
