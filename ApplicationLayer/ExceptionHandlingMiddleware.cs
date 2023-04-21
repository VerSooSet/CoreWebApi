using System.Text.Json;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Encodings.Web;
using ApplicationLayer.Exceptions;

namespace ApplicationLayer
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message);
            
            var response = context.Response;

            if (_environment.IsProduction())
            {
                response.ContentType = Text.Plain;

                switch (exception)
                {
                    case ApplicationException ex:
                        if (ex.Message.Contains("Unauthorized"))
                        {
                            response.StatusCode = (int)HttpStatusCode.Forbidden;
                            break;
                        }
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
                }
                await context.Response.WriteAsync("Feature to get negative detailed responce, whats wrong in detail");
            }
            else if (_environment.IsDevelopment())
            {
                response.ContentType = "application/json";

                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = exception.Message,
                    DetailStackTrace = exception.StackTrace != null ? exception.StackTrace : string.Empty,
                    InnerExceptionMessage = exception.InnerException != null ? exception.InnerException.Message : string.Empty
                };

                string result = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
