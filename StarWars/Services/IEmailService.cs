namespace StarWars.Services;

public interface IEmailService
{
    public bool SendEmailSmtpGmail(string toName, string toEmail, string subject, string body);
}