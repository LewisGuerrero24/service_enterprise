using System.Net;
using System.Reflection.Metadata;
using serviceEnterprise.Domain.Exceptions;

// Middleware para saber manejar las excepciones y el stacktrace

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await Handle(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (DomainException ex)
        {
            await Handle(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception)
        {
            await Handle(context, "Internal server error", HttpStatusCode.InternalServerError);
        }
    }

    private static async Task Handle(
        HttpContext context,
        string message,
        HttpStatusCode statusCode
    )
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            success = false,
            statusCode = context.Response.StatusCode,
            message
        };
        await context.Response.WriteAsJsonAsync(response);
    }

}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      