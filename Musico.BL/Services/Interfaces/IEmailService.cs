namespace Musico.BL.Services;

public interface IEmailService
{
    Task SendEmailConfirmation();
    Task AccountVerify(string userToken);
}