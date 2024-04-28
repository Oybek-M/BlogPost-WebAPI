using System.Net;


namespace BlogPost.Application.Common.Exceptions;

public class StatusCodeException(HttpStatusCode statusCode,
                                 string message)
    : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}
