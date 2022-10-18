using System.Net;

namespace HRMS.API.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            //catch (ArgumentException ex)
            //{
            //    _logger.LogError($"Something went wrong: {ex}");
            //    await ClintSideExceptionAsync(context, ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong. Unhandle exception: {ex}");
                await HandleServerExceptionAsync(context, ex.Message);
            }
        }
        //private Task ClintSideExceptionAsync(HttpContext context, string errorMsg)
        //{
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    return context.Response.WriteAsync(new ErrorDetails
        //    {
        //        StatusCode = context.Response.StatusCode,
        //        Message = $"Client Side Error: {errorMsg}."
        //    }.ToString());
        //}
        private Task HandleServerExceptionAsync(HttpContext context, string errorMsg)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Internal Serval Error: {errorMsg}."
            }.ToString()); 
        }
        
    }
}
