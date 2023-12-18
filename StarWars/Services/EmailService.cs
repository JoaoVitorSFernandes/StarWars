using System.Net;
using System.Net.Mail;
using StarWars;

namespace StarWars.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    
    public EmailService(IConfiguration configuration)
        => _configuration = configuration;

    public bool SendEmailSmtpGmail(string toName, string toEmail, string subject, string body)
    {
        var smtp = new SmtpConfiguration();
        _configuration.GetSection("SmtpConfigurations").Bind(smtp);

        var smtpClient = new SmtpClient(smtp.Host, smtp.Port);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(smtp.UserEmail, smtp.Password);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        var emailMessage = new MailMessage();
        emailMessage.From = new MailAddress(smtp.UserEmail, smtp.UserName);
        emailMessage.Subject = subject;
        emailMessage.Body = body;
        emailMessage.IsBodyHtml = true;
        emailMessage.Priority = MailPriority.Normal;
        emailMessage.To.Add(new MailAddress(toEmail, toName));

        try
        {
            smtpClient.Send(emailMessage);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}