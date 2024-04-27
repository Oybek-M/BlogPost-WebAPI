using Microsoft.OpenApi.Expressions;
using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.DTOs;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using BlogPost.Application.DTOs.Common;

namespace BlogPost.WebApi.Middlewares;

public class ExceptionHandleMiddleware(RequestDelegate requestDelegate)
{
    private readonly RequestDelegate _request = requestDelegate;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (StatusCodeException except)
        {
            await ClientErrorHandleAsync(context, except);
        }
        catch (Exception exception)
        {
            await ServerErrorHandleAsync(context, exception);
        }
    }

    public async Task ClientErrorHandleAsync(HttpContext context, StatusCodeException exception)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exception.Message,
            StatusCode = (int)exception.StatusCode
        };

        context.Response.StatusCode = result.StatusCode;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }

    public async Task ServerErrorHandleAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exception.Message,
            StatusCode = 500
        };

        context.Response.StatusCode = result.StatusCode;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}
