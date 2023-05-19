using System.Net;
using System.Text.Json;
// These three lines are to distinguish them from EntityFramework classes that have the same name
using BadRequestException = ApiCustomer.Exceptions.BadRequestException;
using KeyNotFoundException = ApiCustomer.Exceptions.KeyNotFoundException;
using NotFoundException = ApiCustomer.Exceptions.NotFoundException;
namespace ApiCustomer.Exceptions
{
    // This will be a middleware
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate _next) 
        {
            this._next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // ErrorResponseDto structure creation in line
            HttpStatusCode statusCode;
            DateTime timeStamp = DateTime.Now;
            string message;
            string? stackTrace;

            var exType = ex.GetType();
            if (exType == typeof(BadRequestException))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exType == typeof(KeyNotFoundException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(NotFoundException))
            {
                statusCode= HttpStatusCode.NotFound;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            message= ex.Message;
            stackTrace= ex.StackTrace;

            // Creating inline object
            var ErrorResponseDto = JsonSerializer.Serialize(
                // serializing a new object    
                new
                    {
                        statusCode, timeStamp, message, stackTrace
                    }
                );
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;
            return context.Response.WriteAsync(ErrorResponseDto);
        }
    }
}
