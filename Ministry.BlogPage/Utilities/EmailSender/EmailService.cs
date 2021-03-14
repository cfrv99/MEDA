using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Utilities.EmailSender
{
    public interface IEmailService
    {
        string Send(MessageModel model);
    }
    public class EmailService : IEmailService
    {
        [Obsolete]
        public string Send(MessageModel model)
        {
            var mimeMessage = CreateMimeMessageFromEmailMessage(model);
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com",
                465, true);
                smtpClient.Authenticate("avmshoppingbaku@gmail.com",
                "AVM8387398");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
            return "Email sent successfully";
        }

        [Obsolete]
        private MimeMessage CreateMimeMessageFromEmailMessage(MessageModel model)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("avmshoppingbaku@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("office@adm.az"));
            mimeMessage.Subject = model.Subject;

            var text = string.Format($"Ad:{model.Name}," + Environment.NewLine +
                $"Tel:{model.Phone}," + Environment.NewLine +
                $"Email:{model.Email}," + Environment.NewLine +
                $"Mesaj:{model.Message}");

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = text };
            return mimeMessage;
        }
    }
}
