using MailKit.Net.Smtp;
using MimeKit;

namespace SendingEmailsWithMailkit;

internal class Program
{
    static void Main(string[] args)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Mohamed ElHelaly", "me5260287@gmail.com"));
        message.To.Add(new MailboxAddress("Me", "melhelaly43@gmail.com"));
        message.Subject = "How you doin?";

        var builder = new BodyBuilder();
        builder.TextBody = @"Hey Alice,
            What are you up to this weekend? Monica is throwing one of her parties on
            Saturday and I was hoping you could make it.
            Will you be my +1?
            -- Joey";

        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            // Connect to the SMTP server
            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            // Authenticate with the sender's email and password
            client.Authenticate("me5260287@gmail.com", "zceciztawusozybf");

            // Send the email
            client.Send(message);

            // Disconnect
            client.Disconnect(true);
        }

        Console.WriteLine("Email sent successfully!");
    }
}
