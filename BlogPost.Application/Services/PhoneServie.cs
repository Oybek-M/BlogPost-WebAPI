using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace BlogPost.Application.Services;

public class PhoneServie(IConfiguration configuration) : IPhoneService
{
    private readonly IConfiguration _config = configuration;

    public Task SendMessageToPhoneAsync(string phoneNumber, string message)
    {
        throw new StatusCodeException(HttpStatusCode.OK, "Coming soon with 'eskiz.uz'");
    }
}
