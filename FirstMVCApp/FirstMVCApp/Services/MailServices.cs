﻿using FirstMVCApp.Models.MailServ;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FirstMVCApp.Services
{
    public sealed class SendMailService : ISendMailService
    {
        private readonly IOptions<Mail> _mailOptions;
        private readonly string _login;
        private readonly string _password;

        public SendMailService(IOptions<Mail> mail, IConfiguration config)
        {
            _mailOptions = mail;
            _login = config["Mail:Login"];
            _password = config["Mail:Password"];
        }

        public void Send(string subj, string body)
        {
            var options = _mailOptions.Value;
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(_login, _login));
            mimeMessage.To.Add(new MailboxAddress(options.To, options.To));
            mimeMessage.Subject = subj;

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            var client = new SmtpClient();
            client.Connect(options.Host, options.Port, false);
            client.Authenticate(_login, _password);
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
