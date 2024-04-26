namespace BlogPost.Application.Interfaces;

public interface IEmailService
{
    Task SendMessageToEmailAsync(string to, string subject, string message);
}
