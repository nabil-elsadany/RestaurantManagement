using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Options;
using RazorLight;
using RestaurantManagement.Models;
using System.Net;
using System.Net.Mail;

namespace RestaurantManagement.Servisies
{
    public class EmailService : IEmailService
    {
        private readonly IOptionsMonitor<EmailSettings> _emailSettings;
        private readonly RazorLightEngine _lightEngin;

        public EmailService(IOptionsMonitor<EmailSettings> emailSettings, RazorLightEngine lightEngin)
        {
            _emailSettings = emailSettings;
            _lightEngin = lightEngin;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var settings = _emailSettings.CurrentValue;


          //  ده الكود تالي استخدمته عشان اعمل ايميل تيمبليت من غير مكتبات
        using (var client = new SmtpClient(settings.SmtpServer, settings.Port))
            {


                client.Credentials = new NetworkCredential(settings.SenderEmail, settings.SenderPassword);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(settings.SenderEmail, settings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }

        }
    }
}

