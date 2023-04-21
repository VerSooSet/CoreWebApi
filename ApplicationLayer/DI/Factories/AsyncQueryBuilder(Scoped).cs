using Queries.Abstractions;

namespace ApplicationLayer.DI.Factories
{
    public class AsyncQueryBuilder : IAsyncQueryBuilder
    {
        private readonly IServiceProvider _serviceProvider;
        public AsyncQueryBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IAsyncQueryFor<TResult> For<TResult>()
        {
            return _serviceProvider.GetService<IAsyncQueryFor<TResult>>();
        }
    }
}
