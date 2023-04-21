using Database.N;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.Common;

namespace Domain.Filters
{
    //будем завершать транзакцию для того чтобы не получить не согласованного состояния приложения с бд.
    public class TransactionFilter: IAsyncActionFilter
    {
        private readonly IDbCurrentTransactionProvider dbCurrentTransactionProvider;

        public TransactionFilter(IDbCurrentTransactionProvider dbCurrentTransactionProvider)
        {
            this.dbCurrentTransactionProvider = dbCurrentTransactionProvider ?? throw new ArgumentNullException(nameof(dbCurrentTransactionProvider));
        }
               
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext actionExecutedContext = await next();
            
            if (dbCurrentTransactionProvider.IsInitialized)
            {
                DbTransaction dbTransaction = await dbCurrentTransactionProvider.GetCurrentTransactionAsync();

                if (actionExecutedContext.Exception != null)
                {
                    await dbTransaction.RollbackAsync();
                }
                else
                {
                    await dbTransaction.CommitAsync();
                }
            }
        }
    }
}
