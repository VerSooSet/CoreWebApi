using Api.Requests.Abstractions;

namespace ApplicationLayer.DI.Factories
{
    public class AsyncRequestHandlerFactory: IAsyncRequestHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AsyncRequestHandlerFactory(IServiceProvider provider)
        {
            _serviceProvider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IAsyncRequestHandler<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            var asyncRequestHandler = _serviceProvider.GetService<IAsyncRequestHandler<TRequest, TResponse>>();
            if (asyncRequestHandler == null)
                throw new ArgumentNullException(nameof(asyncRequestHandler));
            return asyncRequestHandler;
        }

        public IAsyncRequestHandler<TRequest> Create<TRequest>()
            where TRequest : IRequest
        {
            var asyncRequestHandler = _serviceProvider.GetService<IAsyncRequestHandler<TRequest>>();
            if (asyncRequestHandler == null)
                throw new ArgumentNullException(nameof(asyncRequestHandler));
            return asyncRequestHandler;
        }
    }
}
