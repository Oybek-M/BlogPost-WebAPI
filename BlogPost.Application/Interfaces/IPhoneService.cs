namespace BlogPost.Application.Interfaces;

public interface IPhoneService
{
    Task SendMessageToPhoneAsync(string phoneNumber, string message);
}
