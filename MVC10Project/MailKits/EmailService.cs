using MailKit.Net.Smtp;
using MimeKit;

namespace MVC10Project.MailKits
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Админ", "FROMtest@yandex.ru"));    
            emailMessage.To.Add(new MailboxAddress("", email));         
            emailMessage.Subject = subject;
           

            emailMessage.Body = new TextPart("Plain")   
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465);        
                await client.AuthenticateAsync("FROMtest@yandex.ru", "3Gb-SJW-Tdf-293");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
