
using Restaurants.Domain.Exceptions;
using System.Net;

namespace Resturants.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
           await next.Invoke(context);
        }
        catch(NotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("Somethink went wrong");
        }
    }
}
