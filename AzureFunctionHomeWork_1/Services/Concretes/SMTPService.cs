using AzureFunctionHomeWork_1.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionHomeWork_1.Services.Concretes
{
    public class SMTPService : ISMTPService
    {

        private readonly IConfiguration _configuration;

        public SMTPService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendSMTP(string email, string message)
        {
            string senderEmail = _configuration["SMTP:Email"];
            string senderPassword = _configuration["SMTP:Code"];

            string emailBody = @$"
<h1>Salam email istifaide eden sexs</h1>
";

            MailMessage mailMessage = new MailMessage(senderEmail, email)
            {
                Subject = "Message",
                Body = message,
                IsBodyHtml = true,
            };

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = int.Parse(_configuration["SMTP:PortNum"]),
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);

        }
    }
}
