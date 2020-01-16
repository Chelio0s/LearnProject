using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace LearnProject.Services
{
    public class EmailService: IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Team Learn Project .Net", "learnproject.net@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            try
            {
                using (var client = new SmtpClient())
                {

                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("learnproject.net@gmail.com", "x56CCGqWQe4U4c4111!$@!");
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            
        }
    }
}
