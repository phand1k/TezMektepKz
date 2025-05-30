using TezMektepKz.Exceptions;

namespace TezMektepKz
{
    // Middleware/ExceptionHandlingMiddleware.cs
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                _logger.LogWarning(ex, "Бизнес-исключение");
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Системная ошибка");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Внутренняя ошибка сервера.");
            }
        }
    }

}
