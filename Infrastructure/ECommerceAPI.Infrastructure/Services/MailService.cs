using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.OptionsModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECommerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly MailOptions _mailOptions;
        readonly IConfiguration _configuration;
        public MailService(IOptions<MailOptions> options, IConfiguration configuration)
        {
            _mailOptions = options.Value;
            _configuration = configuration;
        }



        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_mailOptions.Username, "E-Ticaret", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _mailOptions.Host;
            await smtp.SendMailAsync(mail);
        }

        public async Task SendResetPasswordMailAsync(string to, string userId, string resetToken)
        {
            string mail=$"Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"{_configuration["AngularClientUrl"]}/update-password/{userId}/{resetToken}\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...<br><br><br>E-Ticaret";

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail);
        }

        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName, string userSurname)
        {
            string mail = $"Merhaba {userName} {userName},<br>{orderDate} tarihinde vermiş olduğunuz {orderCode} kodlu sipariş kargoya verilmiştir.<br><br><br>İyi Günler...<br>E-Ticaret";

            await SendMailAsync(to, $"{orderCode} Kodlu Sipariş Hakkında", mail);
        }
    }
}
