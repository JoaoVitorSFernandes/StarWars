namespace StarWars;

public class SmtpConfiguration
{
    public string Host { get; set; }
    public int Port { get; set; } = 25;
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
}