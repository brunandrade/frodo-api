using Core.Api.Logs;
using Core.Validations;
using Core.Validations.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Core.Api.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private string _projectName;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, string projetoName)
    {
        _logger = logger;
        _projectName = projetoName;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorResult = string.Empty;
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        switch (exception)
        {
            case BusinessException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResult = BuildExceptionResultJson(HttpStatusCode.BadRequest, exception);
                break;
            case AccessDenniedException:
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                errorResult = BuildExceptionResultJson(HttpStatusCode.Forbidden, exception);
                break;
            case UnauthorizedException:
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorResult = BuildExceptionResultJson(HttpStatusCode.Unauthorized, exception);
                break;
            case NotFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                errorResult = BuildExceptionResultJson(HttpStatusCode.NotFound, exception);
                break;
            default:
                var log = GenerateLog(context, exception);
                errorResult = JsonConvert.SerializeObject(new
                {
                    log
                });

                break;
        }

        return context.Response.WriteAsync(errorResult);
    }

    private string BuildExceptionResultJson(HttpStatusCode statusCode, Exception exception)
    {
        var erros = new List<ErrorMessage>();
        if (exception is BusinessException)
        {
            var businessException = exception as BusinessException;
            erros = businessException?.Errors?.ToList() ?? erros;
        }

        var result = JsonConvert.SerializeObject(new
        {
            exception.Message,
            Errors = erros
        });

        return result;
    }

    private Log GenerateLog(HttpContext context, Exception exception)
    {
        var log = new Log
        {
            InnerExceptionMessage = exception?.InnerException?.Message,
            Message = exception?.Message,
            StackTrace = exception?.StackTrace,
            Source = exception?.Source,
            Path = context.Request?.Path.Value,
            Module = _projectName
        };

        _logger.LogError(JsonConvert.SerializeObject(log));

        return log;
    }
}

