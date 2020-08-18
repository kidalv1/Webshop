using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Webshop.BL
{
    public class EmailService
    {
        public void SendMail(string email, string id, string subject, string body)
        {
            //TODO aanpassen waarden email!
            // Plug in your email service here to send an email.
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("apschoolnet@gmail.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("apschoolnet@gmail.com", "apNet123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public void SendInvoice(string email, string subject, string body)
        {
            //TODO aanpassen waarden email!
            // Plug in your email service here to send an email.
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("apschoolnet@gmail.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;
            mail.Attachments.Add(new Attachment(@"\Invoices\Bestelling.pdf"));

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("apschoolnet@gmail.com", "apNet123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            foreach (Attachment attachment in mail.Attachments)
            {
                attachment.Dispose();
            }
        }
    }
}
