namespace Musico.BL.DTOs.Options;

public class EmailOptions
{
    public const string Name="SmtpSettings";
    public string Host { get; set; }
    public int Port { get; set; }
    public string Sender { get; set; }
    public string Password { get; set; }
}