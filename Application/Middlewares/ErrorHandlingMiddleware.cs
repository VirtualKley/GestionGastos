using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Application.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (InvalidOperationException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                ex.Message
            );
        }
        catch(UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.Unauthorized,
                ex.Message
            );    
        }
        catch(KeyNotFoundException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.Unauthorized,
                ex.Message
            );    
        }
        catch
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.InternalServerError,
                "Ocurrio un error interno en el servidor"
            );
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message
    )
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            status = (int)statusCode,
            message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }

}