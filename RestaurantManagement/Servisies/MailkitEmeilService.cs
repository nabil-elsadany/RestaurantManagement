using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using RestaurantManagement.Models;

namespace RestaurantManagement.Servisies
{
    public class MailkitEmeilService: IMailkitEmeilService
    {
        
        private readonly IOptionsMonitor<EmailSettings> _options;

        public MailkitEmeilService(IOptionsMonitor<EmailSettings> options)
        {
            _options = options;
        }

        public async Task SendEmailWithMailkitAsync(string toEmail, string subject, string htmlBody, CancellationToken ct = default)
        {
            // (A) اجلب أحدث الاعدادات (يدعم التغيير أثناء التشغيل)
            var settings = _options.CurrentValue;

            // (B) ابني رسالة MIME
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(settings.SenderName, settings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlBody
            };

            message.Body = bodyBuilder.ToMessageBody();

            // (C) ارسال عبر SMTP
            using var client = new SmtpClient();

            // اتصال آمن - StartTLS (شائع على المنفذ 587)
            await client.ConnectAsync(settings.SmtpServer, settings.Port, SecureSocketOptions.StartTls, ct);

            // مصادقة (لو فيها بيانات)
            if (!string.IsNullOrWhiteSpace(settings.SenderEmail) && !string.IsNullOrWhiteSpace(settings.SenderPassword))
            {
                await client.AuthenticateAsync(settings.SenderEmail, settings.SenderPassword, ct);
            }

            // ارسال الرسالة
            await client.SendAsync(message, ct);

            // فصل الاتصال بأمان
            await client.DisconnectAsync(true, ct);
        }
    }

}

